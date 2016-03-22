namespace Teleimot.Common.Tools
{
	using System;

    public static class Helper
    {
		private static readonly Lazy<Random> LazyRandom = new Lazy<Random>();

	    public static Random Randomizer
	    {
		    get
		    {
			    return Helper.LazyRandom.Value;
		    }
	    }
	}
}