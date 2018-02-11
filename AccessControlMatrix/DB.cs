using System;
using System.Collections.Generic;

namespace AccessControlMatrix
{
    static class DB
    {
        /// <summary>
        /// Initialises the database
        /// </summary>
        static public void Init()
        {
            Grant("alex", new String[] { "read", "write", "grant" }, "skynet.doc");
            Grant("alex", new String[] { "read", "write", "grant" }, "ai_research.7z");
            Grant("alex", new String[] { "read", "write", "grant" }, "overwatch.exe");
            Grant("evgeny", new String[] { "read" }, "skynet.doc");
            Grant("evgeny", new String[] { "write" }, "ai_research.7z");
            Grant("evgeny", new String[] { "grant" }, "overwatch.exe");
        }

        static Dictionary<Type, List<NamedObject>> dbObjects = new Dictionary<Type, List<NamedObject>> {
            {typeof(User), new List<NamedObject>
            {
                new User("alex", "123", true),
                new User("evgeny"),
                new User("vasiliy")
            } },
            {typeof(File), new List<NamedObject>
            {
                new File("skynet.doc", "Skynet is a global computer system"),
                new File("ai_research.7z", "AI will conquer the world!!!"),
                new File("overwatch.exe", "Welcome to Overwatch, Soldier 78!")
            } },
            {typeof(Permission), new List<NamedObject>
            {
                new Permission("read"),
                new Permission("write"),
                new Permission("grant")
            } }
        };

        static public Dictionary<User, Dictionary<File, HashSet<Permission>>> permissionMatrix =
            new Dictionary<User, Dictionary<File, HashSet<Permission>>>();

        static public void GetListOfFiles(User user)
        {
            foreach (File file in dbObjects[typeof(File)])
            {
                String output = file.name + ": ";
                try
                {
                    if (permissionMatrix[user][file].Count > 0)
                    {
                        List<String> fileRights = new List<string>();
                        foreach (Permission permission in permissionMatrix[user][file])
                            fileRights.Add(permission.name);
                        output += String.Join(", ", fileRights);
                    }
                    else
                        output += "no rights";
                }
                catch (KeyNotFoundException)
                {
                    output += "no rights";
                }
                Console.WriteLine(output);
            }
        }

        static private void CheckPermissions(User user, File file, Permission permission)
        {
            try
            {
                if (!permissionMatrix[user][file].Contains(permission))
                    throw new NoPermissionError(permission, file);
            }
            catch (KeyNotFoundException)
            {
                throw new NoPermissionError(permission, file);
            }
        }

        static private File GetFileByPermission(User user, String filename, String permissionName)
        {
            Permission permission = GetByName<Permission>(permissionName);
            File file = GetByName<File>(filename);
            try
            {
                if (!permissionMatrix[user][file].Contains(permission))
                    throw new NoPermissionError(permission, file);
                else
                    return file;
            }
            catch (KeyNotFoundException)
            {
                throw new NoPermissionError(permission, file);
            }
        }

        static public void Read(User user, String filename)
        {
            Console.WriteLine(GetFileByPermission(user, filename, "read").Read());
        }

        static public void Write(User user, String filename, String content)
        {
            GetFileByPermission(user, filename, "write").Write(content);
        }

        static public void Grant(User user, String destinationUsername, 
            IEnumerable<String> newPermissionsNames, String filename)
        {
            Grant(destinationUsername, newPermissionsNames, GetFileByPermission(user, filename, "grant"));
        }

        static private void Grant(String destinationUsername,
            IEnumerable<String> newPermissionsNames, String filename)
        {
            Grant(destinationUsername, newPermissionsNames, GetByName<File>(filename));
        }

        static private void Grant(String destinationUsername,
           IEnumerable<String> newPermissionsNames, File file) {
            User destinationUser = GetByName<User>(destinationUsername);
            HashSet<Permission> newPermissions = new HashSet<Permission>();
            foreach (String permissionName in newPermissionsNames)
                newPermissions.Add(GetByName<Permission>(permissionName));
            if (!permissionMatrix.ContainsKey(destinationUser))
                permissionMatrix.Add(destinationUser, new Dictionary<File, HashSet<Permission>> { { file, newPermissions } });
            else if (!permissionMatrix[destinationUser].ContainsKey(file))
                permissionMatrix[destinationUser].Add(file, newPermissions);
            else
                permissionMatrix[destinationUser][file].UnionWith(newPermissions);
        }

        static private void Add<T>(NamedObject obj) where T: NamedObject
        {
            dbObjects[typeof(T)].Add(obj);
        }

        static private T GetByName<T>(String name) where T: NamedObject
        {
            T result = (T)dbObjects[typeof(T)].Find(obj => obj.name == name);
            if (result == null)
                throw new NotFoundException(typeof(T), name);
            return result;
        }

        static public User GetUserByLoginPass(String login, String password)
        {
            User user = GetByName<User>(login);
            if (!user.CheckPassword(password))
                throw new Exception("Invalid combination of login and password");
            return user;
        }

        public class NotFoundException : ApplicationException
        {
            public NotFoundException(Type objectType, string objectName) 
                : base(objectType.Name + " \"" + objectName + "\" not found") { }
        }

        public class NoPermissionError : ApplicationException
        {
            public NoPermissionError(Permission permission, File file) 
                : base("You have no \"" + permission.name + "\" permission for file \"" + file.name + "\"") { }
        }
    }
}
