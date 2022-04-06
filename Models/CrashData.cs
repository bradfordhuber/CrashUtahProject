using System;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace CrashUtahProject.Models
{
    public class CrashData
    {
        public float work_zone_related_True { get; set; }
        public float pedestrian_involved_True { get; set; }
        public float bicyclist_involved_True { get; set; }
        public float motorcycle_involved_True { get; set; }
        public float improper_restraint_True { get; set; }
        public float unrestrained_True { get; set; }
        public float dui_True { get; set; }
        public float intersection_related_True { get; set; }
        public float wild_animal_related_True { get; set; }
        public float overturn_rollover_True { get; set; }
        public float commercial_motor_veh_involved_True { get; set; }
        public float teenage_driver_involved_True { get; set; }
        public float older_driver_involved_True { get; set; }
        public float single_vehicle_True { get; set; }
        public float distracted_driving_True { get; set; }
        public float drowsy_driving_True { get; set; }
        public float day_Monday { get; set; }
        public float day_Saturday { get; set; }
        public float day_Sunday { get; set; }
        public float day_Tuesday { get; set; }
        public float roadway_departure_True { get; set; }
        public float route_68 { get; set; }
        public float county_name_WASATCH { get; set; }
        public float time_frame_5am_9am { get; set; }
        public float time_frame_9am_12pm { get; set; }


        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                work_zone_related_True, pedestrian_involved_True,
       bicyclist_involved_True, motorcycle_involved_True,
       improper_restraint_True, unrestrained_True, dui_True,
       intersection_related_True, wild_animal_related_True,
       overturn_rollover_True, commercial_motor_veh_involved_True,
       teenage_driver_involved_True, older_driver_involved_True,
       single_vehicle_True, distracted_driving_True, drowsy_driving_True,
       roadway_departure_True , route_68, county_name_WASATCH,
       day_Monday, day_Saturday, day_Sunday, day_Tuesday,
       time_frame_5am_9am, time_frame_9am_12pm,
            };
            int[] dimensions = new int[] { 1, 25 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}