using Courses.Domain;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments;
using Tasogarewa.Domain;

namespace CoursesWebAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        
        public CustomExceptionHandlerMiddleware(RequestDelegate Next)=>
            this.next = Next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
         
        }
        private Task HandleExceptionAsync(HttpContext context,Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException<AppUser>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Basket>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Announcement>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Comment>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Review>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<CodeEx>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Test>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Section>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Mentor>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Course>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<InBasketCourse>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<InListCourse>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Lection>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<LectionNotice>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Chat>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<CourseChat>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<CourseStudent>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<ArchivedCourse>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<ArchivedCourses>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<LikedCourse>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<LikedCourses>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<UserNamedCourseList>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<UserNamedList>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<UserWishList>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<UserWishedCourse>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Notification>:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotFoundException<Question>:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error=exception.Message});
            }
            return context.Response.WriteAsync(result);
        }
    }
}
