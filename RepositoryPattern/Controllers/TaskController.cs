using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskEntity task)
        {
            try
            {
                await _unitOfWork.TaskRepository.CreateTaskAsync(task);
                await _unitOfWork.SaveChangesAsync();

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the task.");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _unitOfWork.TaskRepository.GetAllTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving tasks.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var task = await _unitOfWork.TaskRepository.GetTaskByIdAsync(id);
                if (task != null)
                {
                    return Ok(task);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the task.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskEntity taskData)
        {
            try
            {
                var existingTask = await _unitOfWork.TaskRepository.GetTaskByIdAsync(id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                existingTask.Description = taskData.Description;
                existingTask.IsCompleted = taskData.IsCompleted;

                await _unitOfWork.TaskRepository.UpdateTaskAsync(existingTask);
                await _unitOfWork.SaveChangesAsync();

                return Ok(existingTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the task.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var existingTask = await _unitOfWork.TaskRepository.GetTaskByIdAsync(id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                await _unitOfWork.TaskRepository.DeleteTaskAsync(id);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the task.");
            }
        }

    }
}
