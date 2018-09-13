using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_lab_Fakes_Door_control
{
    public class DoorControl
    {
        IDoor _Door;
        IAlarm _Alarm;
        public IValidator _Validator;
        INotifier _Notifier;

        public DoorControl(IDoor door, IAlarm alarm, IValidator validator, INotifier notifier)
        {
            _Door = door;
            _Alarm = alarm;
            _Validator = validator;
            _Notifier = notifier;
        }

        public void OpenDoor()
        {
            if(_Door.GetDoorState()==false)
            {
                _Door.Open();
            }
        }

        public void CloseDoor()
        {
            if (_Door.GetDoorState() == true)
            {
                _Door.Close();
            }
        }

        public void RaiseAlarm()
        {
            _Alarm.RaiseAlarm();
        }

        public void NotifyEntry(bool accessGranted)
        {
            _Notifier.NotifyUserAccessGranted(accessGranted);
        }

        public bool ValidateEntry()
        {
            return _Validator.ValidateEntry();
        }

        public void RequestEntry()
        {
            if(ValidateEntry()==true)
            {
                OpenDoor();
                NotifyEntry(true);
            }
            else
            {
                CloseDoor();
                NotifyEntry(false);
            }
        }

        public void DoorBreached()
        {
            RaiseAlarm();
            OpenDoor();
        }
    }
}
