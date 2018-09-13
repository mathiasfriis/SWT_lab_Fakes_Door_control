using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_lab_Fakes_Door_control;

namespace DoorControl_Tests_Unit
{
    class FakeDoor : IDoor
    {
        bool _doorState = false;
        public int _nTimesOpened { get; set; }
        public int _nTimesClosed { get; set; }

        public FakeDoor()
        {
            _nTimesClosed = 0;
            _nTimesOpened = 0;
        }
        public void Close()
        {
            if (GetDoorState() == true)
            {
                _nTimesClosed++;
                _doorState = false;
            }
        }

        public bool GetDoorState()
        {
            return _doorState;
        }

        public void SetDoorState(bool isOpen)
        {
            _doorState = isOpen;
        }

        public void Open()
        {
            if (GetDoorState() == false)
            {
                _nTimesOpened++;
                _doorState = true;
            }
        }
    }

    public class FakeValidator : IValidator
    {
        public bool ValidateEntry()
        {
            return true;
        }
    }

    public class FakeAlarm : IAlarm
    {
        public int _nTimesAlarmRaised { get; set; }

        public FakeAlarm()
        {
            _nTimesAlarmRaised = 0;
        }

        public void RaiseAlarm()
        {
            _nTimesAlarmRaised++;
        }
    }

    class FakeNotifier : INotifier
    {
        int _nTimesAccessGranted;
        int _nTimesAccessDenied;

        public FakeNotifier()
        {
            _nTimesAccessGranted = 0;
            _nTimesAccessDenied = 0;
        }

        public void NotifyUserAccessGranted(bool accessGranted)
        {
            if(accessGranted)
            {
                _nTimesAccessGranted++;
            }
            else
            {
                _nTimesAccessDenied++;
            }
        }
    }
}
