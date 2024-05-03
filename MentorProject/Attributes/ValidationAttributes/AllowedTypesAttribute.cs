using System.ComponentModel.DataAnnotations;

namespace MentorProject.Attributes.ValidationAttributes
{

	public class AllowedTypesAttribute:ValidationAttribute
	{
		private string[] _types;
		public AllowedTypesAttribute(params string[] types)
		{
			_types = types;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			List<IFormFile> formFiles = new List<IFormFile>();

			if (value is List<IFormFile>) formFiles = (List<IFormFile>)value;
			else if (value is IFormFile file) formFiles.Add(file);
			foreach (var formFile in formFiles)
			{
				if (!_types.Contains(formFile.ContentType))
				{
					string errorMessages = "File must be one of these types: " + String.Join(", ", _types);
					return new ValidationResult(errorMessages);
				}
			}
			return ValidationResult.Success;
			;
		}

	}
}
