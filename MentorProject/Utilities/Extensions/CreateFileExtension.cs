namespace MentorProject.Utilities.Extensions
{
    public static class CreateFileExtension
    {
        public static string CreateFile(this IFormFile file, string environment, string path)
        {
            string imageName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(environment, path, imageName);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return imageName;
        }

        public static bool DeleteFile(this IFormFile file, string environment, string path, string imageName)
        {
			string fullPath = Path.Combine(environment, path, imageName);
            if(File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;

        }
    }
}
