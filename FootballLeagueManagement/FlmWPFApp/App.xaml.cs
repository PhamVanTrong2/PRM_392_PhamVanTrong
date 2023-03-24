using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }
        public App()
        {
            //Config for DependencyInjection (01)
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {

            services.AddSingleton(typeof(IRankingRepository), typeof(RankingRepository));
            services.AddSingleton<RankingWindow>();
            services.AddSingleton(typeof(IMatchRepository), typeof(MatchRepository));
            services.AddSingleton<MatchWindow>();
            services.AddSingleton(typeof(IClubRepository), typeof(ClubRepository));
            services.AddSingleton<MatchWindow>();
            services.AddSingleton(typeof(IStadiumRepository), typeof(StadiumRepository));
            services.AddSingleton<MatchWindow>();
            services.AddSingleton(typeof(IMatchResultRepository), typeof(MatchResultRepository));
            services.AddSingleton<MatchWindow>();
            services.AddSingleton(typeof(IAccountRepository), typeof(AccountRepository));
            services.AddSingleton(typeof(IClubRepository), typeof(ClubRepository));
            services.AddSingleton<Login>();
            services.AddSingleton<DetailsMatch>();


        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var windowFLM = serviceProvider.GetService<Login>();
            windowFLM.Show();
        }
    }
}
