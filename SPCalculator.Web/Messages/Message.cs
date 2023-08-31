namespace SPCalculator.Web.Messages
{
    public static class Message
    {
        public static class Sprint
        {
            public static string Add(string sprintName) => $"{sprintName} sprinti başarıyla eklendi";
            public static string Update(string sprintName) => $"{sprintName} sprinti başarıyla güncellendi";
            public static string Delete(string sprintName) => $"{sprintName} sprinti başarıyla silindi";
            public static string UndoDelete(string sprintName) => $"{sprintName} sprinti başarıyla geri getirildi";
        }

        public static class Function
        {
            public static string Add(string functionName) => $"{functionName} fonksiyonu başarıyla eklendi";
            public static string Update(string functionName) => $"{functionName} fonksiyonu başarıyla güncellendi";
            public static string Delete(string functionName) => $"{functionName} fonksiyonu başarıyla silindi";
            public static string UndoDelete(string functionName) => $"{functionName} fonksiyonu başarıyla geri getirildi";
        }

        public static class Parameter
        {
            public static string Add(string parameterName) => $"{parameterName} parametresi başarıyla eklendi";
            public static string Update(string parameterName) => $"{parameterName} parametresi başarıyla güncellendi";
            public static string Delete(string parameterName) => $"{parameterName} parametresi başarıyla silindi";
            public static string UndoDelete(string parameterName) => $"{parameterName} parametresi başarıyla geri getirildi";
        }
    }
}
