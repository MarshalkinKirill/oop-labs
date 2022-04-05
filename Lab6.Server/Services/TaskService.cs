using lab6.BlLayer;
using System;

namespace Lab6.Server.Services
{
    public class TaskService
    {
        private IJsonContext jsonContext;
        private JsonRepository jsonRepository;

        public TaskService(JsonContext jsonContext)
        {
            jsonRepository = new JsonRepository(jsonContext);
        }

        public string GetAll()
        {
            return jsonRepository.GetAllTasks();
        }

        public string FindById(int id)
        {
            return jsonRepository.FindTaskById(id);
        }

        public string FindByTime(DateTime time)
        {
            return jsonRepository.FindTaskByTime(time);
        }

        public string FindByChanges()
        {
            return jsonRepository.FindTaskByChanges();
        }

        public string FindByImplementorId(int id)
        {
            return jsonRepository.FindTaskByImplementorId(id);
        }

        public void Close(int id, int closerId)
        {
            jsonRepository.CloseTask(id, closerId);
        }

        public void AddComment(int id, int commentId, int commentatorId)
        {
            jsonRepository.AddCommentToTask(id, commentId, commentatorId);
        }

        public void CreateTask(int id, int sprintId, string name, string description, int reporteId)
        {
            jsonRepository.CreateTask(id, sprintId, name, description, reporteId);
        }
    }
}
