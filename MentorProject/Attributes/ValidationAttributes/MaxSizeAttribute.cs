using System.ComponentModel.DataAnnotations;

namespace MentorProject.Attributes.ValidationAttributes
{
	public class MaxSizeAttribute : ValidationAttribute
	{
		private int _byteSize;
		public MaxSizeAttribute(int byteSize)
		{
			_byteSize = byteSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			List<IFormFile> formFiles = new List<IFormFile>();

			if (value is List<IFormFile>) formFiles = (List<IFormFile>)value;
			else if (value is IFormFile file) formFiles.Add(file);

			foreach (var file in formFiles)
			{
				if (file.Length > _byteSize)
				{
					double mb = file.Length / 1024d / 1024d;
					return new ValidationResult($"File size must be less than or equal to {mb}MBs");
				}
			}
			return ValidationResult.Success;

		}
	}
}
