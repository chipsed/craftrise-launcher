using System;
using System.Diagnostics;

internal class RiseUtils
{
	public static bool isValidDLLs(int id)
	{
		Process processById = Process.GetProcessById(id);
		if (processById == null)
		{
			return true;
		}
		bool flag = false;
		try
		{
			string value = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToLower();
			foreach (ProcessModule module in processById.Modules)
			{
				try
				{
					string text = module.FileName.ToLower();
					if (text.StartsWith(value))
					{
						flag = true;
						Console.WriteLine("Not allowed #3: " + module.FileName);
					}
					string text2 = module.ModuleName.ToLower();
					if (text2.Contains("hack") || text2.Contains("speed") || text2.Contains("cheat") || text2.Contains("click"))
					{
						flag = true;
						Console.WriteLine("Not allowed #1: " + module.FileName);
					}
					if (!text2.Equals("javaw.exe") && !text2.Equals("java.exe") && text.Contains(".exe"))
					{
						flag = true;
						Console.WriteLine("Not allowed #2: " + module.FileName);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
			return true;
		}
		return !flag;
	}

	public static bool isCheatEngineRunning()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			try
			{
				if (process.ProcessName.ToLower().Contains("cheatengine"))
				{
					return true;
				}
			}
			catch (Exception)
			{
			}
		}
		return false;
	}
}
