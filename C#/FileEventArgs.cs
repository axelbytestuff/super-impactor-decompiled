using System;

namespace SuperImpactor
{
	public class FileEventArgs : EventArgs
	{
		public ExtraData data;

		public FileEventArgs(ExtraData v)
		{
			this.data = v;
		}
	}
}