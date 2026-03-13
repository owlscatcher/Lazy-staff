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
                "(personnelnumber, factorynumber, devicetype, yearofissue, sentdate, verificationdate, devicelocation, verifiedto, solutionnunber, gan, state, dateoftechnicalinspection) " +
                "VALUES (@personnelNumber, @factoryNumber, @deviceType, @yearOfIssue, @sentDate, @verificationDate, @deviceLocation, @verifiedTo, @solutionNumber, @gan, @state, @dateOfTechnicalInspection)";

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
                "dateoftechnicalinspection = @dateOfTechnicalInspection " +
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
                SerialId = reader.GetInt32(reader.GetOrdinal("factorynumber")),
                DeviceTypeId = reader.GetInt32(reader.GetOrdinal("devicetype")),
                ReleaseYear = reader.GetInt32(reader.GetOrdinal("yearofissue")),
                Loaction = reader.GetString(reader.GetOrdinal("devicelocation")),
                Status = reader.GetInt32(reader.GetOrdinal("state")),
                DateOfShipment = reader.IsDBNull(reader.GetOrdinal("sentdate"))
                    ? DateTime.MinValue
                    : reader.GetDateTime(reader.GetOrdinal("sentdate")),
                DateCheck = reader.IsDBNull(reader.GetOrdinal("verificationdate"))
                    ? DateTime.MinValue
                    : reader.GetDateTime(reader.GetOrdinal("verificationdate")),
                ValidTo = reader.IsDBNull(reader.GetOrdinal("verifiedto"))
                    ? DateTime.MinValue
                    : reader.GetDateTime(reader.GetOrdinal("verifiedto")),
                Solution = reader.IsDBNull(reader.GetOrdinal("solutionnunber"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("solutionnunber")),
                IsGun = !reader.IsDBNull(reader.GetOrdinal("gan")) && reader.GetBoolean(reader.GetOrdinal("gan")),
                DateOfTechnicalInspection = reader.IsDBNull(reader.GetOrdinal("dateoftechnicalinspection"))
                    ? DateTime.MinValue
                    : reader.GetDateTime(reader.GetOrdinal("dateoftechnicalinspection"))
            };
        }

        private static void FillCommandParameters(NpgsqlCommand command, Device device)
        {
            command.Parameters.AddWithValue("@personnelNumber", device.Id);
            command.Parameters.AddWithValue("@factoryNumber", device.SerialId);
            command.Parameters.AddWithValue("@deviceType", device.DeviceTypeId);
            command.Parameters.AddWithValue("@yearOfIssue", device.ReleaseYear);

            command.Parameters.AddWithValue("@sentDate",
                device.DateOfShipment == DateTime.MinValue ? (object)DBNull.Value : device.DateOfShipment);
            command.Parameters.AddWithValue("@verificationDate",
                device.DateCheck == DateTime.MinValue ? (object)DBNull.Value : device.DateCheck);
            command.Parameters.AddWithValue("@deviceLocation",
                string.IsNullOrWhiteSpace(device.Loaction) ? (object)DBNull.Value : device.Loaction);
            command.Parameters.AddWithValue("@verifiedTo",
                device.ValidTo == DateTime.MinValue ? (object)DBNull.Value : device.ValidTo);
            command.Parameters.AddWithValue("@solutionNumber",
                string.IsNullOrWhiteSpace(device.Solution) ? (object)DBNull.Value : device.Solution);
            command.Parameters.AddWithValue("@gan", device.IsGun);
            command.Parameters.AddWithValue("@state", device.Status);
            command.Parameters.AddWithValue("@dateOfTechnicalInspection",
                device.DateOfTechnicalInspection == DateTime.MinValue ? (object)DBNull.Value : device.DateOfTechnicalInspection);
        }
    }
}
