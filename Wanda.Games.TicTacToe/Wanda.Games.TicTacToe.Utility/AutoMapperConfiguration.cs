using System;

namespace Wanda.Games.TicTacToe.Utility
{
    public static class AutoMapperConfiguration
    {
        private static bool _isInit;

        public static void Configure()
        {
            if (_isInit) return;

            //Mapper.Initialize(profile => { profile.AddProfile<MapperProfile>(); });
            //Mapper.Configuration.AssertConfigurationIsValid();
            _isInit = true;
        }
    }
}
