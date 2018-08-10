using System;

namespace SuperImpactor
{
	public class ReturnModel
	{
		private int m_return_code;

		private string m_message;

		public string message
		{
			get
			{
				return this.m_message;
			}
			set
			{
				this.m_message = value;
			}
		}

		public int return_code
		{
			get
			{
				return this.m_return_code;
			}
			set
			{
				this.m_return_code = value;
			}
		}

		public ReturnModel()
		{
		}
	}
}