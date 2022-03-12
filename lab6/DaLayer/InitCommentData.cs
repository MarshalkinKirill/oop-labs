using System;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab6.DaLayer
{
	public class InitCommentData
	{
		private string CommentPath;
		private List<Comment> CommentData;
		public InitCommentData(string path)
		{
			CommentPath = path;
			CommentData = new List<Comment>();
			InitFile(path);
			CommentData.Add(new Comment(11, 1, "qwe"));
			CommentData.Add(new Comment(12, 1, "asd"));
			SaveComments(CommentData, path);
		}
		private void InitFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		private void SaveComments(List<Comment> comments, string path)
		{

			File.AppendAllText(path, JsonSerializer.Serialize(comments));
		}
		public void AddComment(Comment comment)
		{
			InitFile(CommentPath);
			CommentData.Add(comment);
			SaveComments(CommentData, CommentPath);
		}
	}
}
