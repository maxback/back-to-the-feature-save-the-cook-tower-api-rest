using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.CrossCutting.Utils
{
	[AttributeUsage(AttributeTargets.All)]
	public class NomeParaUsuarioAttribute : Attribute
	{
		public string Nome { get; }
		public NomeParaUsuarioAttribute(string nome)
		{
			Nome = nome;
		}
	}
}
