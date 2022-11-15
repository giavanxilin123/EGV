using System.Text.RegularExpressions;

namespace EGV.Contracts.Utils
{
    public static class Generate
    {
        public static string GenerateCategoryId(string categoryName)
        {
            var categoryNameSplit = categoryName.Split(' ');
            var categoryId = string.Join("", 
                categoryNameSplit
                    .Select(word => word[0])
                    .Where(character => Regex.IsMatch(character.ToString(), @"^[a-zA-Z]+$")));
            return categoryId;
        }
    }
}