//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.LivoxRosDriver
{
    [Serializable]
    public class CustomMsgMsg : Message
    {
        public const string k_RosMessageName = "livox_ros_driver/CustomMsg";
        public override string RosMessageName => k_RosMessageName;

        //  Livox publish pointcloud msg format.
        public HeaderMsg header;
        //  ROS standard message header
        public ulong timebase;
        //  The time of first point
        public uint point_num;
        //  Total number of pointclouds
        public byte lidar_id;
        //  Lidar device id number
        public byte[] rsvd;
        //  Reserved use
        public CustomPointMsg[] points;
        //  Pointcloud data

        public CustomMsgMsg()
        {
            this.header = new HeaderMsg();
            this.timebase = 0;
            this.point_num = 0;
            this.lidar_id = 0;
            this.rsvd = new byte[3];
            this.points = new CustomPointMsg[0];
        }

        public CustomMsgMsg(HeaderMsg header, ulong timebase, uint point_num, byte lidar_id, byte[] rsvd, CustomPointMsg[] points)
        {
            this.header = header;
            this.timebase = timebase;
            this.point_num = point_num;
            this.lidar_id = lidar_id;
            this.rsvd = rsvd;
            this.points = points;
        }

        public static CustomMsgMsg Deserialize(MessageDeserializer deserializer) => new CustomMsgMsg(deserializer);

        private CustomMsgMsg(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.timebase);
            deserializer.Read(out this.point_num);
            deserializer.Read(out this.lidar_id);
            deserializer.Read(out this.rsvd, sizeof(byte), 3);
            deserializer.Read(out this.points, CustomPointMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.timebase);
            serializer.Write(this.point_num);
            serializer.Write(this.lidar_id);
            serializer.Write(this.rsvd);
            serializer.WriteLength(this.points);
            serializer.Write(this.points);
        }

        public override string ToString()
        {
            return "CustomMsgMsg: " +
            "\nheader: " + header.ToString() +
            "\ntimebase: " + timebase.ToString() +
            "\npoint_num: " + point_num.ToString() +
            "\nlidar_id: " + lidar_id.ToString() +
            "\nrsvd: " + System.String.Join(", ", rsvd.ToList()) +
            "\npoints: " + System.String.Join(", ", points.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
