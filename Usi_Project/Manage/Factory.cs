﻿using Usi_Project.Settings;
using Usi_Project.Manage;
using Newtonsoft.Json;
using Usi_Project.DataSaver;

namespace Usi_Project.Manage
{
    public class Factory
    {
        private DirectorManager _directorManager;
        private PatientManager _patientManager;
        private SecretaryManager _secretaryManager;
        private DoctorManager _doctorManager;
        private RoomManager _roomManager;
        private AppointmentManager _appointmentManager;
        private AnamnesaManager _anamnesaManager;
        private RequestManager _requestManager;
        private Saver _saver;

        public Factory()
        {
        }

        public Saver Saver
        {
            get => _saver;
            set => _saver = value;
        }

        public Factory(FileSettings fileSettings,Saver saver)
        {
            _directorManager = new DirectorManager(fileSettings.DirectorFilename, this);
            _patientManager = new PatientManager(fileSettings.PatientFilename, this);
            _secretaryManager = new SecretaryManager(fileSettings.SecretaryFilename, this);
            _doctorManager = new DoctorManager(fileSettings.DoctorFilename, this);
            _roomManager = new RoomManager(fileSettings.OperatingRoomsFn, fileSettings.OverviewRoomsFn,
                fileSettings.RetiringRoomsFn, this);
            _appointmentManager = new AppointmentManager(fileSettings.AppointmentsFn, this);
            _anamnesaManager = new AnamnesaManager(fileSettings.AnamnesaFn, this);
            _requestManager = new RequestManager(fileSettings.RequestedFn, this);
            _saver = saver;
        }

        public RequestManager RequestManager
        {
            get => _requestManager;
            set => _requestManager = value;
        }

        public AnamnesaManager AnamnesaManager
        {
            get => _anamnesaManager;
            set => _anamnesaManager = value;
        }

        public AppointmentManager AppointmentManager
        {
            get => _appointmentManager;
            set => _appointmentManager = value;
        }

        public void LoadData()
        {

            _directorManager.LoadData();
            _patientManager.LoadData();
            _secretaryManager.LoadData();
            _doctorManager.LoadData();
            _roomManager.LoadData();
            _appointmentManager.LoadData();
            _anamnesaManager.LoadData();
            _requestManager.LoadData();

        }

        public RoomManager RoomManager
        {
            get => _roomManager;
            set => _roomManager = value;
        }

        public DirectorManager DirectorManager
        {
            get => _directorManager;
        }

        public PatientManager PatientManager
        {
            get => _patientManager;
        }

        public SecretaryManager SecretaryManager
        {
            get => _secretaryManager;
        }

        public DoctorManager DoctorManager
        {
            get => _doctorManager;
        }
    }

}