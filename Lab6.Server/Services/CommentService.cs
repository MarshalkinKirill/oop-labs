namespace Lab6.Server.Services
{
    public class CommentService
    {
        private JsonRepository jsonRepository;
        
        public CommentService(JsonContext jsonContext)
        {
            jsonRepository = new JsonRepository(jsonContext);
        }

        public string FindById(int id)
        {
            return jsonRepository.FindCommentById(id);
        }

        public void CreateComment(int id, int employeeId, string text)
        {
            jsonRepository.CreateComment(id, employeeId, text);
        }
    }
}
