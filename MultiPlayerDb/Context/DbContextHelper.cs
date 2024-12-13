namespace MultiPlayerDb.Context
{
	public static class DbContextHelper
	{

		public static Type GetContext(string worldName) 
		{
			if (string.IsNullOrEmpty(worldName))
				return null;

			char firstChar = char.ToUpper(worldName[0]);

			if (firstChar >= 'A' && firstChar <= 'G')
				return typeof(WorldContextAG);
			else if (firstChar >= 'H' && firstChar <= 'P')
				return typeof(WorldContextHP);
			else 
				return typeof(WorldContextQZ);
			
		}

	}
}
