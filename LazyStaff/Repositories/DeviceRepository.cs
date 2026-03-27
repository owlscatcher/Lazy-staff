using System;
using System.Collections.Generic;
using LazyStaff.Models;
using Npgsql;

namespace LazyStaff.Repositories
{
    class DeviceRepository : IDeviceRepository
    {
        private readonly string _tableName;

        public DeviceRepository()
        {
            var settings = new DatabaseConnectionSettings();
            _tableName = settings.DeviceTable;
        }

        public IEnumerable<Device> GetAll()
        {
            var devices = new List<Device>();
            var connection = DatabaseConnection.Instance.Connection;

            using (var command = new NpgsqlCommand(
                $"SELECT * FROM {_tableName} ORDER BY personnelnumber", connection))
            {
                EnsureConnectionOpen(connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        devices.Add(MapDevice(reader));
                    }
                }
            }

            return devices;
        }

        public Device GetById(int id)
        {
            var connection = DatabaseConnection.Instance.Connection;

            using (var command = new NpgsqlCommand(
                $"SELECT * FROM {_tableName} WHERE personnelnumber = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);

                EnsureConnectionOpen(connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapDevice(reader);
                    }
                }
            }

            return null;
        }

        public void Add(Device device)
        {
            var connection = DatabaseConnection.Instance.Connection;

            var sql =
                $"INSERT INTO {_tableName} " +
                "(personnelnumber, factorynumber, devicetype, yearofissue, sentdate, verificationdate, devicelocation, verifiedto, solutionnunber, gan, state, techdate, mc_interval, sphere_sreum_id, sphere_sreum_name, passport_id) " +
                "VALUES (@personnelNumber, @factoryNumber, @deviceType, @yearOfIssue, @sentDate, @verificationDate, @deviceLocation, @verifiedTo, @solutionNumber, @gan, @state, @techdate, @mc_interval, @sphere_sreum_id, @sphere_sreum_name, @passport_id)";

            using (var command = new NpgsqlCommand(sql, connection))
            {
                FillCommandParameters(command, device);

                EnsureConnectionOpen(connection);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Device device)
        {
            var connection = DatabaseConnection.Instance.Connection;

            var sql =
                $"UPDATE {_tableName} SET " +
                "factorynumber = @factoryNumber, " +
                "devicetype = @deviceType, " +
                "yearofissue = @yearOfIssue, " +
                "sentdate = @sentDate, " +
                "verificationdate = @verificationDate, " +
                "devicelocation = @deviceLocation, " +
                "verifiedto = @verifiedTo, " +
                "solutionnunber = @solutionNumber, " +
                "gan = @gan, " +
                "state = @state, " +
                "techdate = @techdate, " +
                "mc_interval = @mc_interval, " +
                "sphere_sreum_id = @sphere_sreum_id, " + 
                "sphere_sreum_name = @sphere_sreum_name, " +
                "passport_id = @passport_id " +
                "WHERE personnelnumber = @personnelNumber";

            using (var command = new NpgsqlCommand(sql, connection))
            {
                FillCommandParameters(command, device);

                EnsureConnectionOpen(connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            var connection = DatabaseConnection.Instance.Connection;

            using (var command = new NpgsqlCommand(
                $"DELETE FROM {_tableName} WHERE personnelnumber = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);

                EnsureConnectionOpen(connection);
                command.ExecuteNonQuery();
            }
        }

        private static void EnsureConnectionOpen(NpgsqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private static Device MapDevice(NpgsqlDataReader reader)
        {
            return new Device
            {
                Id = reader.GetInt32(reader.GetOrdinal("personnelnumber")),
                SerialId = reader.GetString(reader.GetOrdinal("factorynumber")),
                DeviceTypeName = reader.GetString(reader.GetOrdinal("devicetype")),
                ReleaseYear = reader.GetInt32(reader.GetOrdinal("yearofissue")),
                Loaction = reader.IsDBNull(reader.GetOrdinal("devicelocation"))
                    ? String.Empty
                    : reader.GetString(reader.GetOrdinal("devicelocation")),
                Status = reader.GetInt32(reader.GetOrdinal("state")),
                DateOfShipment = reader.IsDBNull(reader.GetOrdinal("sentdate"))
                    ? DateTime.MinValue
                    : reader.GetDateTime(reader.GetOrdinal("sentdate")),
                DateCheck = reader.IsDBNull(reader.GetOrdinal("verificationdate"))
                    ? DateTime.MinValue
                    : reader.GetDateTime(reader.GetOrdinal("verificationdate")),
                ValidTo = reader.IsDBNull(reader.GetOrdinal("verifiedto"))
                    ? String.Empty
                    : reader.GetString(reader.GetOrdinal("verifiedto")),
                Solution = reader.IsDBNull(reader.GetOrdinal("solutionnunber"))
                    ? String.Empty
                    : reader.GetString(reader.GetOrdinal("solutionnunber")),
                IsGun = !reader.IsDBNull(reader.GetOrdinal("gan")) && reader.GetBoolean(reader.GetOrdinal("gan")),
                DateOfTechnicalInspection = reader.IsDBNull(reader.GetOrdinal("techdate"))
                    ? String.Empty
                    : reader.GetString(reader.GetOrdinal("techdate")),
                MetrologicalControlInterval = reader.GetInt32(reader.GetOrdinal("mc_interval")),
                SphereSREUMId = reader.IsDBNull(reader.GetOrdinal("sphere_sreum_id"))
                    ? 0
                    : reader.GetInt32(reader.GetOrdinal("sphere_sreum_id")),
                SphereSREUMName = reader.IsDBNull(reader.GetOrdinal("sphere_sreum_name"))
                    ? String.Empty
                    : reader.GetString(reader.GetOrdinal("sphere_sreum_name")),
                PassportId = reader.IsDBNull(reader.GetOrdinal("passport_id"))
                    ? 0
                    : reader.GetInt32(reader.GetOrdinal("passport_id"))
            };
    }

        private static void FillCommandParameters(NpgsqlCommand command, Device device)
        {
            command.Parameters.AddWithValue("@personnelNumber", device.Id);
            command.Parameters.AddWithValue("@factoryNumber", device.SerialId);
            command.Parameters.AddWithValue("@deviceType", device.DeviceTypeName);
            command.Parameters.AddWithValue("@yearOfIssue", device.ReleaseYear);

            command.Parameters.AddWithValue("@sentDate",
                device.DateOfShipment == DateTime.MinValue ? (object)DBNull.Value : device.DateOfShipment);
            command.Parameters.AddWithValue("@verificationDate",
                device.DateCheck == DateTime.MinValue ? (object)DBNull.Value : device.DateCheck);
            command.Parameters.AddWithValue("@deviceLocation",
                string.IsNullOrWhiteSpace(device.Loaction) ? (object)DBNull.Value : device.Loaction);
            command.Parameters.AddWithValue("@verifiedTo",
                string.IsNullOrWhiteSpace(device.ValidTo) ? (object)DBNull.Value : device.ValidTo);
            command.Parameters.AddWithValue("@solutionNumber",
                string.IsNullOrWhiteSpace(device.Solution) ? (object)DBNull.Value : device.Solution);
            command.Parameters.AddWithValue("@gan", device.IsGun);
            command.Parameters.AddWithValue("@state", device.Status);
            command.Parameters.AddWithValue("@techdate",
                string.IsNullOrWhiteSpace(device.DateOfTechnicalInspection) ? (object)DBNull.Value : device.DateOfTechnicalInspection);
            command.Parameters.AddWithValue("@mc_interval", device.MetrologicalControlInterval);
            command.Parameters.AddWithValue("@sphere_sreum_id", device.SphereSREUMId);
            command.Parameters.AddWithValue("@sphere_sreum_name", 
                string.IsNullOrWhiteSpace(device.SphereSREUMName) ? (object)DBNull.Value : device.SphereSREUMName);
            command.Parameters.AddWithValue("@passport_id", device.PassportId);
        }
    }
}
