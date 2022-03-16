using System;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab6.DaLayer
{
	public class ReadCommentData
	{

		public List<Comment> ReadComentsData(string path)
		{
			List<Comment> commentlist = new List<Comment>();
			commentlist = JsonSerializer.Deserialize<List<Comment>>(File.ReadAllText(path));
			return commentlist;
		}
	}
}
