using System;

using Xamarin.Forms;
using SQLite;

namespace TheForum
{
	public interface IFileHelper
	{
		string GetLocalFilePath(string filename);
	}
}

