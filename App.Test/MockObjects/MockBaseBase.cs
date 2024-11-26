namespace App.Test.MockObjects
{
    public static class MockBase
    {
        public static string GenerateStringLeng(int size)
        {
            var rtn = "";
            for (int i = 0; i < size; i++)
            {
                rtn = rtn + "a";
            }
            return rtn;


        }
    }
}