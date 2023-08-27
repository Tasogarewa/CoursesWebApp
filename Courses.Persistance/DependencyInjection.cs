using Castle.Core.Configuration;
using Courses.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;
using Tasogarewa.Persistance.Common;
using Tasogarewa.Persistance.Services;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Tasogarewa.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<ITasogarewaDbContext, TasogarewaDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CoursesWebAPI")).UseLazyLoadingProxies();
            
            });
            services.AddSignalRCore();
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<Image>, Repository<Image>>();
            services.AddScoped<IRepository<Notification>, Repository<Notification>>();
            services.AddScoped<IRepository<Message>, Repository<Message>>();
            services.AddScoped<IRepository<Chat>, Repository<Chat>>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            services.AddScoped<IRepository<Comment>, Repository<Comment>>();
            services.AddScoped<IRepository<Announcement>, Repository<Announcement>>();
            services.AddScoped<IRepository<Basket>, Repository<Basket>>();
            services.AddScoped<IRepository<CodeEx>, Repository<CodeEx>>();
            services.AddScoped<IRepository<Review>, Repository<Review>>();
            services.AddScoped<IRepository<CourseStudent>, Repository<CourseStudent>>();
            services.AddScoped<IRepository<InBasketCourse>, Repository<InBasketCourse>>();
            services.AddScoped<IRepository<InListCourse>, Repository<InListCourse>>();
            services.AddScoped<IRepository<LectionNotice>, Repository<LectionNotice>>();
            services.AddScoped<IRepository<Lection>, Repository<Lection>>();
            services.AddScoped<IRepository<Mentor>, Repository<Mentor>>();
            services.AddScoped<IRepository<Question>, Repository<Question>>();
            services.AddScoped<IRepository<Section>, Repository<Section>>();
            services.AddScoped<IRepository<Test>, Repository<Test>>();
            services.AddScoped<IRepository<ArchivedCourse>, Repository<ArchivedCourse>>();
            services.AddScoped<IRepository<ArchivedCourses>, Repository<ArchivedCourses>>();
            services.AddScoped<IRepository<CourseChat>, Repository<CourseChat>>();
            services.AddScoped<IRepository<LikedCourse>, Repository<LikedCourse>>();
            services.AddScoped<IRepository<LikedCourses>, Repository<LikedCourses>>();
            services.AddScoped<IRepository<UserNamedCourseList>, Repository<UserNamedCourseList>>();
            services.AddScoped<IRepository<UserNamedList>, Repository<UserNamedList>>();
            services.AddScoped<IRepository<UserWishList>, Repository<UserWishList>>();
            services.AddScoped<IRepository<UserWishedCourse>, Repository<UserWishedCourse>>();

            services.AddScoped<IAnnouncmentService, AnnouncmentService>();
            services.AddScoped<IArchivedCourseService, ArchivedCourseService>();
            services.AddScoped<IBasketCourseService, BasketCourseService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<ICodeExService, CodeExService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICourseChatService, CourseChatService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseStudentService, CourseStudentService>();
            services.AddScoped<ILectionNoticeService, LectionNoticeService>();
            services.AddScoped<ILectionService, LectionService>();
            services.AddScoped<ILikedCourseService, LikedCourseService>();
            services.AddScoped<IListCourseService, ListCourseService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<INamedListService, NamedListService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishedCourseService, WishedCourseService>();


            return services;
        }
    }
}
