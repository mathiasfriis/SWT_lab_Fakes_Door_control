using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWT_lab_Fakes_Door_control;

namespace DoorControl_Tests_Unit
{
    [TestFixture]
    public class DoorContron_UnitTests
    {
        FakeDoor fakeDoor;
        FakeAlarm fakeAlarm;
        FakeNotifier fakeNotifier;
        FakeValidator fakeValidator;
        DoorControl doorControl;

        [SetUp]
        public void SetUp()
        {
            fakeDoor = new FakeDoor();
            fakeAlarm = new FakeAlarm();
            fakeNotifier = new FakeNotifier();
            fakeValidator = new FakeValidator();

            doorControl = new DoorControl(fakeDoor, fakeAlarm, fakeValidator, fakeNotifier);
        }

        #region Door Tests

        #region Call history test
        [Test]
        public void Door_OpenClosedDoor_ReturnsDoorHasBeenOpened()
        {
            fakeDoor.SetDoorState(false);

            doorControl.OpenDoor();

            Assert.That(fakeDoor._nTimesOpened,Is.EqualTo(1));
        }
        
        [Test]
        public void Door_OpenOpenedDoor_ReturnsDoorHasNotBeenOpened()
        {
            fakeDoor.SetDoorState(true);

            doorControl.OpenDoor();

            Assert.That(fakeDoor._nTimesOpened, Is.EqualTo(0));
        }

        [Test]
        public void Door_CloseClosedDoor_ReturnsDoorHasNotBeenClosed()
        {
            fakeDoor.SetDoorState(false);

            doorControl.CloseDoor();

            Assert.That(fakeDoor._nTimesClosed, Is.EqualTo(0));
        }

        [Test]
        public void Door_CloseOpenedDoor_ReturnsDoorHasBeenClosed()
        {
            fakeDoor.SetDoorState(true);

            doorControl.CloseDoor();

            Assert.That(fakeDoor._nTimesClosed, Is.EqualTo(1));
        }
        #endregion


        #region State tests
        [Test]
        public void Door_OpenClosedDoor_ReturnsDoorIsOpen()
        {
            fakeDoor.SetDoorState(false);

            doorControl.OpenDoor();

            Assert.That(fakeDoor.GetDoorState, Is.EqualTo(true));
        }

        [Test]
        public void Door_CloseClosedDoor_ReturnsDoorIsClosed()
        {
            fakeDoor.SetDoorState(false);

            doorControl.CloseDoor();

            Assert.That(fakeDoor.GetDoorState, Is.EqualTo(false));
        }

        [Test]
        public void Door_OpenOpenDoor_ReturnsDoorIsOpen()
        {
            fakeDoor.SetDoorState(true);

            doorControl.OpenDoor();

            Assert.That(fakeDoor.GetDoorState, Is.EqualTo(true));
        }

        [Test]
        public void Door_CloseOpenedDoor_ReturnsDoorIsClosed()
        {
            fakeDoor.SetDoorState(true);

            doorControl.CloseDoor();

            Assert.That(fakeDoor.GetDoorState, Is.EqualTo(false));
        }
        #endregion

        #endregion

        #region Alarm Tests

        [Test]
        public void Alarm_DoNothing_AlarmHasNotBeenRaised()
        {
            Assert.That(fakeAlarm._nTimesAlarmRaised, Is.EqualTo(0));
        }

        [Test]
        public void Alarm_DoorIsBreached_AlarmHasBeenRaised()
        {
            doorControl.DoorBreached();

            Assert.That(fakeAlarm._nTimesAlarmRaised, Is.EqualTo(1));
        }

        [Test]
        public void Alarm_DoorOpened_AlarmHasNotBeenRaised()
        {
            fakeDoor.SetDoorState(false);
            doorControl.OpenDoor();
            Assert.That(fakeAlarm._nTimesAlarmRaised, Is.EqualTo(0));
        }

        [Test]
        public void Alarm_DoorClosed_AlarmHasNotBeenRaised()
        {
            fakeDoor.SetDoorState(true);
            doorControl.CloseDoor();
            Assert.That(fakeAlarm._nTimesAlarmRaised, Is.EqualTo(0));
        }

        #endregion

        //Basically just do the same for fakeValidator and fakeNotifier. GG EZ.
    }
}
