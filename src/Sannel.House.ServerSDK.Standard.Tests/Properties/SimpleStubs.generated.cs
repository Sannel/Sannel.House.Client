using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIApplicationLogEntry : IApplicationLogEntry
    {
        private readonly StubContainer<StubIApplicationLogEntry> _stubs = new StubContainer<StubIApplicationLogEntry>();

        global::System.Guid global::Sannel.House.ServerSDK.IApplicationLogEntry.Id
        {
            get
            {
                return _stubs.GetMethodStub<Id_Get_Delegate>("get_Id").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Id_Set_Delegate>("set_Id").Invoke(value);
            }
        }

        int? global::Sannel.House.ServerSDK.IApplicationLogEntry.DeviceId
        {
            get
            {
                return _stubs.GetMethodStub<DeviceId_Get_Delegate>("get_DeviceId").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DeviceId_Set_Delegate>("set_DeviceId").Invoke(value);
            }
        }

        string global::Sannel.House.ServerSDK.IApplicationLogEntry.ApplicationId
        {
            get
            {
                return _stubs.GetMethodStub<ApplicationId_Get_Delegate>("get_ApplicationId").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<ApplicationId_Set_Delegate>("set_ApplicationId").Invoke(value);
            }
        }

        string global::Sannel.House.ServerSDK.IApplicationLogEntry.Message
        {
            get
            {
                return _stubs.GetMethodStub<Message_Get_Delegate>("get_Message").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Message_Set_Delegate>("set_Message").Invoke(value);
            }
        }

        string global::Sannel.House.ServerSDK.IApplicationLogEntry.Exception
        {
            get
            {
                return _stubs.GetMethodStub<Exception_Get_Delegate>("get_Exception").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Exception_Set_Delegate>("set_Exception").Invoke(value);
            }
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.IApplicationLogEntry.CreatedDate
        {
            get
            {
                return _stubs.GetMethodStub<CreatedDate_Get_Delegate>("get_CreatedDate").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<CreatedDate_Set_Delegate>("set_CreatedDate").Invoke(value);
            }
        }

        public delegate global::System.Guid Id_Get_Delegate();

        public StubIApplicationLogEntry Id_Get(Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Id_Set_Delegate(global::System.Guid value);

        public StubIApplicationLogEntry Id_Set(Id_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int? DeviceId_Get_Delegate();

        public StubIApplicationLogEntry DeviceId_Get(DeviceId_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DeviceId_Set_Delegate(int? value);

        public StubIApplicationLogEntry DeviceId_Set(DeviceId_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string ApplicationId_Get_Delegate();

        public StubIApplicationLogEntry ApplicationId_Get(ApplicationId_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void ApplicationId_Set_Delegate(string value);

        public StubIApplicationLogEntry ApplicationId_Set(ApplicationId_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Message_Get_Delegate();

        public StubIApplicationLogEntry Message_Get(Message_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Message_Set_Delegate(string value);

        public StubIApplicationLogEntry Message_Set(Message_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Exception_Get_Delegate();

        public StubIApplicationLogEntry Exception_Get(Exception_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Exception_Set_Delegate(string value);

        public StubIApplicationLogEntry Exception_Set(Exception_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset CreatedDate_Get_Delegate();

        public StubIApplicationLogEntry CreatedDate_Get(CreatedDate_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void CreatedDate_Set_Delegate(global::System.DateTimeOffset value);

        public StubIApplicationLogEntry CreatedDate_Set(CreatedDate_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubICreateHelper : ICreateHelper
    {
        private readonly StubContainer<StubICreateHelper> _stubs = new StubContainer<StubICreateHelper>();

        global::Sannel.House.ServerSDK.IDevice global::Sannel.House.ServerSDK.ICreateHelper.CreateDevice()
        {
            return _stubs.GetMethodStub<CreateDevice_Delegate>("CreateDevice").Invoke();
        }

        public delegate global::Sannel.House.ServerSDK.IDevice CreateDevice_Delegate();

        public StubICreateHelper CreateDevice(CreateDevice_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Sannel.House.ServerSDK.ITemperatureSetting global::Sannel.House.ServerSDK.ICreateHelper.CreateTemperatureSetting()
        {
            return _stubs.GetMethodStub<CreateTemperatureSetting_Delegate>("CreateTemperatureSetting").Invoke();
        }

        public delegate global::Sannel.House.ServerSDK.ITemperatureSetting CreateTemperatureSetting_Delegate();

        public StubICreateHelper CreateTemperatureSetting(CreateTemperatureSetting_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Sannel.House.ServerSDK.IApplicationLogEntry global::Sannel.House.ServerSDK.ICreateHelper.CreateApplicationLogEntry()
        {
            return _stubs.GetMethodStub<CreateApplicationLogEntry_Delegate>("CreateApplicationLogEntry").Invoke();
        }

        public delegate global::Sannel.House.ServerSDK.IApplicationLogEntry CreateApplicationLogEntry_Delegate();

        public StubICreateHelper CreateApplicationLogEntry(CreateApplicationLogEntry_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Sannel.House.ServerSDK.ITemperatureEntry global::Sannel.House.ServerSDK.ICreateHelper.CreateTemperatureEntry()
        {
            return _stubs.GetMethodStub<CreateTemperatureEntry_Delegate>("CreateTemperatureEntry").Invoke();
        }

        public delegate global::Sannel.House.ServerSDK.ITemperatureEntry CreateTemperatureEntry_Delegate();

        public StubICreateHelper CreateTemperatureEntry(CreateTemperatureEntry_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIDevice : IDevice
    {
        private readonly StubContainer<StubIDevice> _stubs = new StubContainer<StubIDevice>();

        int global::Sannel.House.ServerSDK.IDevice.Id
        {
            get
            {
                return _stubs.GetMethodStub<Id_Get_Delegate>("get_Id").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Id_Set_Delegate>("set_Id").Invoke(value);
            }
        }

        string global::Sannel.House.ServerSDK.IDevice.Name
        {
            get
            {
                return _stubs.GetMethodStub<Name_Get_Delegate>("get_Name").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Name_Set_Delegate>("set_Name").Invoke(value);
            }
        }

        string global::Sannel.House.ServerSDK.IDevice.Description
        {
            get
            {
                return _stubs.GetMethodStub<Description_Get_Delegate>("get_Description").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Description_Set_Delegate>("set_Description").Invoke(value);
            }
        }

        int global::Sannel.House.ServerSDK.IDevice.DisplayOrder
        {
            get
            {
                return _stubs.GetMethodStub<DisplayOrder_Get_Delegate>("get_DisplayOrder").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DisplayOrder_Set_Delegate>("set_DisplayOrder").Invoke(value);
            }
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.IDevice.DateCreated
        {
            get
            {
                return _stubs.GetMethodStub<DateCreated_Get_Delegate>("get_DateCreated").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DateCreated_Set_Delegate>("set_DateCreated").Invoke(value);
            }
        }

        bool global::Sannel.House.ServerSDK.IDevice.IsReadOnly
        {
            get
            {
                return _stubs.GetMethodStub<IsReadOnly_Get_Delegate>("get_IsReadOnly").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<IsReadOnly_Set_Delegate>("set_IsReadOnly").Invoke(value);
            }
        }

        public delegate int Id_Get_Delegate();

        public StubIDevice Id_Get(Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Id_Set_Delegate(int value);

        public StubIDevice Id_Set(Id_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Name_Get_Delegate();

        public StubIDevice Name_Get(Name_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Name_Set_Delegate(string value);

        public StubIDevice Name_Set(Name_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Description_Get_Delegate();

        public StubIDevice Description_Get(Description_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Description_Set_Delegate(string value);

        public StubIDevice Description_Set(Description_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int DisplayOrder_Get_Delegate();

        public StubIDevice DisplayOrder_Get(DisplayOrder_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DisplayOrder_Set_Delegate(int value);

        public StubIDevice DisplayOrder_Set(DisplayOrder_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset DateCreated_Get_Delegate();

        public StubIDevice DateCreated_Get(DateCreated_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DateCreated_Set_Delegate(global::System.DateTimeOffset value);

        public StubIDevice DateCreated_Set(DateCreated_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate bool IsReadOnly_Get_Delegate();

        public StubIDevice IsReadOnly_Get(IsReadOnly_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void IsReadOnly_Set_Delegate(bool value);

        public StubIDevice IsReadOnly_Set(IsReadOnly_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubITemperatureEntry : ITemperatureEntry
    {
        private readonly StubContainer<StubITemperatureEntry> _stubs = new StubContainer<StubITemperatureEntry>();

        global::System.Guid global::Sannel.House.ServerSDK.ITemperatureEntry.Id
        {
            get
            {
                return _stubs.GetMethodStub<Id_Get_Delegate>("get_Id").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Id_Set_Delegate>("set_Id").Invoke(value);
            }
        }

        int global::Sannel.House.ServerSDK.ITemperatureEntry.DeviceId
        {
            get
            {
                return _stubs.GetMethodStub<DeviceId_Get_Delegate>("get_DeviceId").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DeviceId_Set_Delegate>("set_DeviceId").Invoke(value);
            }
        }

        double global::Sannel.House.ServerSDK.ITemperatureEntry.TemperatureCelsius
        {
            get
            {
                return _stubs.GetMethodStub<TemperatureCelsius_Get_Delegate>("get_TemperatureCelsius").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<TemperatureCelsius_Set_Delegate>("set_TemperatureCelsius").Invoke(value);
            }
        }

        double global::Sannel.House.ServerSDK.ITemperatureEntry.Humidity
        {
            get
            {
                return _stubs.GetMethodStub<Humidity_Get_Delegate>("get_Humidity").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Humidity_Set_Delegate>("set_Humidity").Invoke(value);
            }
        }

        double global::Sannel.House.ServerSDK.ITemperatureEntry.Pressure
        {
            get
            {
                return _stubs.GetMethodStub<Pressure_Get_Delegate>("get_Pressure").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Pressure_Set_Delegate>("set_Pressure").Invoke(value);
            }
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.ITemperatureEntry.CreatedDateTime
        {
            get
            {
                return _stubs.GetMethodStub<CreatedDateTime_Get_Delegate>("get_CreatedDateTime").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<CreatedDateTime_Set_Delegate>("set_CreatedDateTime").Invoke(value);
            }
        }

        public delegate global::System.Guid Id_Get_Delegate();

        public StubITemperatureEntry Id_Get(Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Id_Set_Delegate(global::System.Guid value);

        public StubITemperatureEntry Id_Set(Id_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int DeviceId_Get_Delegate();

        public StubITemperatureEntry DeviceId_Get(DeviceId_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DeviceId_Set_Delegate(int value);

        public StubITemperatureEntry DeviceId_Set(DeviceId_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double TemperatureCelsius_Get_Delegate();

        public StubITemperatureEntry TemperatureCelsius_Get(TemperatureCelsius_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void TemperatureCelsius_Set_Delegate(double value);

        public StubITemperatureEntry TemperatureCelsius_Set(TemperatureCelsius_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double Humidity_Get_Delegate();

        public StubITemperatureEntry Humidity_Get(Humidity_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Humidity_Set_Delegate(double value);

        public StubITemperatureEntry Humidity_Set(Humidity_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double Pressure_Get_Delegate();

        public StubITemperatureEntry Pressure_Get(Pressure_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Pressure_Set_Delegate(double value);

        public StubITemperatureEntry Pressure_Set(Pressure_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset CreatedDateTime_Get_Delegate();

        public StubITemperatureEntry CreatedDateTime_Get(CreatedDateTime_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void CreatedDateTime_Set_Delegate(global::System.DateTimeOffset value);

        public StubITemperatureEntry CreatedDateTime_Set(CreatedDateTime_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubITemperatureSetting : ITemperatureSetting
    {
        private readonly StubContainer<StubITemperatureSetting> _stubs = new StubContainer<StubITemperatureSetting>();

        long global::Sannel.House.ServerSDK.ITemperatureSetting.Id
        {
            get
            {
                return _stubs.GetMethodStub<Id_Get_Delegate>("get_Id").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Id_Set_Delegate>("set_Id").Invoke(value);
            }
        }

        int? global::Sannel.House.ServerSDK.ITemperatureSetting.DayOfWeek
        {
            get
            {
                return _stubs.GetMethodStub<DayOfWeek_Get_Delegate>("get_DayOfWeek").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DayOfWeek_Set_Delegate>("set_DayOfWeek").Invoke(value);
            }
        }

        int? global::Sannel.House.ServerSDK.ITemperatureSetting.Month
        {
            get
            {
                return _stubs.GetMethodStub<Month_Get_Delegate>("get_Month").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Month_Set_Delegate>("set_Month").Invoke(value);
            }
        }

        bool global::Sannel.House.ServerSDK.ITemperatureSetting.IsTimeOnly
        {
            get
            {
                return _stubs.GetMethodStub<IsTimeOnly_Get_Delegate>("get_IsTimeOnly").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<IsTimeOnly_Set_Delegate>("set_IsTimeOnly").Invoke(value);
            }
        }

        global::System.DateTimeOffset? global::Sannel.House.ServerSDK.ITemperatureSetting.StartTime
        {
            get
            {
                return _stubs.GetMethodStub<StartTime_Get_Delegate>("get_StartTime").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<StartTime_Set_Delegate>("set_StartTime").Invoke(value);
            }
        }

        global::System.DateTimeOffset? global::Sannel.House.ServerSDK.ITemperatureSetting.EndTime
        {
            get
            {
                return _stubs.GetMethodStub<EndTime_Get_Delegate>("get_EndTime").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<EndTime_Set_Delegate>("set_EndTime").Invoke(value);
            }
        }

        double global::Sannel.House.ServerSDK.ITemperatureSetting.HeatTemperatureC
        {
            get
            {
                return _stubs.GetMethodStub<HeatTemperatureC_Get_Delegate>("get_HeatTemperatureC").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<HeatTemperatureC_Set_Delegate>("set_HeatTemperatureC").Invoke(value);
            }
        }

        double global::Sannel.House.ServerSDK.ITemperatureSetting.CoolTemperatureC
        {
            get
            {
                return _stubs.GetMethodStub<CoolTemperatureC_Get_Delegate>("get_CoolTemperatureC").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<CoolTemperatureC_Set_Delegate>("set_CoolTemperatureC").Invoke(value);
            }
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.ITemperatureSetting.DateCreated
        {
            get
            {
                return _stubs.GetMethodStub<DateCreated_Get_Delegate>("get_DateCreated").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DateCreated_Set_Delegate>("set_DateCreated").Invoke(value);
            }
        }

        global::System.DateTimeOffset global::Sannel.House.ServerSDK.ITemperatureSetting.DateModified
        {
            get
            {
                return _stubs.GetMethodStub<DateModified_Get_Delegate>("get_DateModified").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DateModified_Set_Delegate>("set_DateModified").Invoke(value);
            }
        }

        public delegate long Id_Get_Delegate();

        public StubITemperatureSetting Id_Get(Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Id_Set_Delegate(long value);

        public StubITemperatureSetting Id_Set(Id_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int? DayOfWeek_Get_Delegate();

        public StubITemperatureSetting DayOfWeek_Get(DayOfWeek_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DayOfWeek_Set_Delegate(int? value);

        public StubITemperatureSetting DayOfWeek_Set(DayOfWeek_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int? Month_Get_Delegate();

        public StubITemperatureSetting Month_Get(Month_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Month_Set_Delegate(int? value);

        public StubITemperatureSetting Month_Set(Month_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate bool IsTimeOnly_Get_Delegate();

        public StubITemperatureSetting IsTimeOnly_Get(IsTimeOnly_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void IsTimeOnly_Set_Delegate(bool value);

        public StubITemperatureSetting IsTimeOnly_Set(IsTimeOnly_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset? StartTime_Get_Delegate();

        public StubITemperatureSetting StartTime_Get(StartTime_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void StartTime_Set_Delegate(global::System.DateTimeOffset? value);

        public StubITemperatureSetting StartTime_Set(StartTime_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset? EndTime_Get_Delegate();

        public StubITemperatureSetting EndTime_Get(EndTime_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void EndTime_Set_Delegate(global::System.DateTimeOffset? value);

        public StubITemperatureSetting EndTime_Set(EndTime_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double HeatTemperatureC_Get_Delegate();

        public StubITemperatureSetting HeatTemperatureC_Get(HeatTemperatureC_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void HeatTemperatureC_Set_Delegate(double value);

        public StubITemperatureSetting HeatTemperatureC_Set(HeatTemperatureC_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double CoolTemperatureC_Get_Delegate();

        public StubITemperatureSetting CoolTemperatureC_Get(CoolTemperatureC_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void CoolTemperatureC_Set_Delegate(double value);

        public StubITemperatureSetting CoolTemperatureC_Set(CoolTemperatureC_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset DateCreated_Get_Delegate();

        public StubITemperatureSetting DateCreated_Get(DateCreated_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DateCreated_Set_Delegate(global::System.DateTimeOffset value);

        public StubITemperatureSetting DateCreated_Set(DateCreated_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::System.DateTimeOffset DateModified_Get_Delegate();

        public StubITemperatureSetting DateModified_Get(DateModified_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DateModified_Set_Delegate(global::System.DateTimeOffset value);

        public StubITemperatureSetting DateModified_Set(DateModified_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIHttpClient : IHttpClient
    {
        private readonly StubContainer<StubIHttpClient> _stubs = new StubContainer<StubIHttpClient>();

        string global::Sannel.House.ServerSDK.IHttpClient.GetCookieValue(global::System.Uri uri, string cookieName)
        {
            return _stubs.GetMethodStub<GetCookieValue_Uri_String_Delegate>("GetCookieValue").Invoke(uri, cookieName);
        }

        public delegate string GetCookieValue_Uri_String_Delegate(global::System.Uri uri, string cookieName);

        public StubIHttpClient GetCookieValue(GetCookieValue_Uri_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::Sannel.House.ServerSDK.HttpClientResult> global::Sannel.House.ServerSDK.IHttpClient.GetAsync(global::System.Uri requestUri)
        {
            return _stubs.GetMethodStub<GetAsync_Uri_Delegate>("GetAsync").Invoke(requestUri);
        }

        public delegate global::System.Threading.Tasks.Task<global::Sannel.House.ServerSDK.HttpClientResult> GetAsync_Uri_Delegate(global::System.Uri requestUri);

        public StubIHttpClient GetAsync(GetAsync_Uri_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::Sannel.House.ServerSDK.HttpClientResult> global::Sannel.House.ServerSDK.IHttpClient.PostAsync(global::System.Uri requestUri, global::System.Collections.Generic.IDictionary<string, string> data)
        {
            return _stubs.GetMethodStub<PostAsync_Uri_IDictionaryOfStringString_Delegate>("PostAsync").Invoke(requestUri, data);
        }

        public delegate global::System.Threading.Tasks.Task<global::Sannel.House.ServerSDK.HttpClientResult> PostAsync_Uri_IDictionaryOfStringString_Delegate(global::System.Uri requestUri, global::System.Collections.Generic.IDictionary<string, string> data);

        public StubIHttpClient PostAsync(PostAsync_Uri_IDictionaryOfStringString_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIHttpClient Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIServerContext : IServerContext
    {
        private readonly StubContainer<StubIServerContext> _stubs = new StubContainer<StubIServerContext>();

        bool global::Sannel.House.ServerSDK.IServerContext.IsAuthenticated
        {
            get
            {
                return _stubs.GetMethodStub<IsAuthenticated_Get_Delegate>("get_IsAuthenticated").Invoke();
            }
        }

        global::System.Threading.Tasks.Task<global::Sannel.House.ServerSDK.LoginResult> global::Sannel.House.ServerSDK.IServerContext.LoginAsync(string username, string password)
        {
            return _stubs.GetMethodStub<LoginAsync_String_String_Delegate>("LoginAsync").Invoke(username, password);
        }

        public delegate global::System.Threading.Tasks.Task<global::Sannel.House.ServerSDK.LoginResult> LoginAsync_String_String_Delegate(string username, string password);

        public StubIServerContext LoginAsync(LoginAsync_String_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate bool IsAuthenticated_Get_Delegate();

        public StubIServerContext IsAuthenticated_Get(IsAuthenticated_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIServerContext Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}

namespace Sannel.House.ServerSDK
{
    [CompilerGenerated]
    public class StubIServerSettings : IServerSettings
    {
        private readonly StubContainer<StubIServerSettings> _stubs = new StubContainer<StubIServerSettings>();

        global::System.Uri global::Sannel.House.ServerSDK.IServerSettings.ServerUri
        {
            get
            {
                return _stubs.GetMethodStub<ServerUri_Get_Delegate>("get_ServerUri").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<ServerUri_Set_Delegate>("set_ServerUri").Invoke(value);
            }
        }

        public delegate global::System.Uri ServerUri_Get_Delegate();

        public StubIServerSettings ServerUri_Get(ServerUri_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void ServerUri_Set_Delegate(global::System.Uri value);

        public StubIServerSettings ServerUri_Set(ServerUri_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}