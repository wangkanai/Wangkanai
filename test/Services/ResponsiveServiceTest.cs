// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Wangkanai.Detection.Mocks;
using Wangkanai.Detection.Models;

using Xunit;

namespace Wangkanai.Detection.Services
{
    public class ResponsiveServiceTest
    {
        [Fact]
        public void Ctor_Null()
        {
            var resolver = MockService.ResponsiveService(null!);
            Assert.NotNull(resolver);
            Assert.Equal(Device.Desktop, resolver.View);
        }

        [Fact]
        public void Ctor_Null_Options_Null()
        {
            var resolver = MockService.ResponsiveService(null!, null!);
            Assert.NotNull(resolver);
            Assert.Equal(Device.Desktop, resolver.View);
        }

        [Fact]
        public void DefaultDesktop()
        {
            var options = new ResponsiveOptions();
            options.DefaultDesktop = Device.Desktop;
            options.DefaultTablet  = Device.Desktop;
            options.DefaultMobile  = Device.Desktop;

            Assert.Equal(Device.Desktop, MockService.ResponsiveService("mobile", options).View);
            Assert.Equal(Device.Desktop, MockService.ResponsiveService("tablet", options).View);
            Assert.Equal(Device.Desktop, MockService.ResponsiveService("desktop", options).View);
        }

        [Fact]
        public void DefaultTablet()
        {
            var options = new ResponsiveOptions();
            options.DefaultDesktop = Device.Tablet;
            options.DefaultTablet  = Device.Tablet;
            options.DefaultMobile  = Device.Tablet;

            Assert.Equal(Device.Tablet, MockService.ResponsiveService("mobile", options).View);
            Assert.Equal(Device.Tablet, MockService.ResponsiveService("tablet", options).View);
            Assert.Equal(Device.Tablet, MockService.ResponsiveService("desktop", options).View);
        }

        [Fact]
        public void DefaultMobile()
        {
            var options = new ResponsiveOptions();
            options.DefaultDesktop = Device.Mobile;
            options.DefaultTablet  = Device.Mobile;
            options.DefaultMobile  = Device.Mobile;

            Assert.Equal(Device.Mobile, MockService.ResponsiveService("mobile", options).View);
            Assert.Equal(Device.Mobile, MockService.ResponsiveService("tablet", options).View);
            Assert.Equal(Device.Mobile, MockService.ResponsiveService("desktop", options).View);
        }
    }
}