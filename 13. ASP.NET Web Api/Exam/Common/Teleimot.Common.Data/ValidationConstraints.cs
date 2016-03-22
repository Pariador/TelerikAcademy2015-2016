namespace Teleimot.Common.Data
{
	public static class ValidationConstraints
	{
		public const int EstateTitleMinLength = 5;
		public const int EstateTitleMaxLength = 50;

		public const int EstateDescriptionMinLenth = 10;
		public const int EstateDescriptionMaxLenth = 1000;

		public const int EstateConstructionYearMin = 1800;

		public const int CommentContentMinLength = 10;
		public const int CommentContentMaxLength = 500;

		public const byte MinRating = 1;
		public const byte MaxRating = 5;
	}
}