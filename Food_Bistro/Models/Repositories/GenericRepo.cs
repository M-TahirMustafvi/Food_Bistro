//using Food_Bistro.Models.Interfaces;
//using Microsoft.Data.SqlClient;

//namespace Food_Bistro.Models.Repositories
//{
//	public class GenericRepo<T> : IGenericRepo<T> where T : class
//	{
//		protected readonly string _conStr;
//        public GenericRepo(string conStr)
//        {
//			_conStr = conStr;
//        }
		
//        public bool Add(T entity)
//		{
//			int rows;
//			using (var con = new SqlConnection(_conStr))
//			{
//				con.Open();
				
//				var tableName = typeof(T).Name;
//				var properties = typeof(T).GetProperties().Where(p => p.Name != "id");

//				var columnNames = string.Join(",", properties.Select(p => p.Name));
//				var parameterName = string.Join(",", properties.Select(p=> "@" + p.Name));

//				var query = $"insert into {tableName} ({columnNames}) values ({parameterName})";

//				using(var cmd = new  SqlCommand(query, con))
//				{
//					foreach(var property in properties)
//					{
//						cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(entity));
//					}
//					rows = cmd.ExecuteNonQuery();
//				}
//			}
//			return rows > 0;
//		}
		
//		//public void Delete(int id)
//		//{
//		//	using(var con = new SqlConnection(_conStr))
//		//	{
//		//		var tableName = typeof(T).Name;
//		//		var primaryKey = "id";

//		//		string query = $"delete from {tableName} where {primaryKey} = @id";

//		//		using (var cmd = new SqlCommand(query, con))
//		//		{
//		//			cmd.Parameters.AddWithValue("@id", id);
//		//			cmd.ExecuteNonQuery();
//		//		}
//		//	}
//		//}

//		//public IEnumerable<T> GetAll()
//		//{
//		//	var entities = new List<T>();
//		//	using (var con = new SqlConnection(_conStr))
//		//	{
//		//		var tableName = typeof(T).Name;
//		//		string query = "select * form {tableName}";

//		//		using(var cmd = new SqlCommand(query,con))
//		//		{
//		//			using(var reader = cmd.ExecuteReader())
//		//			{
						
//		//				while(reader.Read())
//		//				{
//		//					entities.Add(MapReaderToObj(reader));
//		//				}
//		//			}
//		//		}
//		//	}
//		//	return entities;
//		//}

//		//public T GetById(int id)
//		//{
//		//	var entity = Activator.CreateInstance<T>();
//		//	using(var con = new SqlConnection(_conStr))
//		//	{
//		//		var tableName = typeof(T).Name;
//		//		string query = $"select * from {tableName} where id = @id";
//		//		using(SqlCommand cmd = new SqlCommand(query, con))
//		//		{
//		//			cmd.Parameters.AddWithValue("id", id);
//		//			using(var reader = cmd.ExecuteReader())
//		//			{
//		//				if(reader.Read())
//		//					entity = MapReaderToObj(reader);
//		//			}
//		//		}
//		//	}
//		//	return entity;
//		//}

//		//public void Update(T entity)
//		//{
//		//	using(SqlConnection con = new SqlConnection(_conStr))
//		//	{
//		//		var tableName = typeof(T).Name;
//		//		var primaryKey = "id";

//		//		var properties = typeof(T).GetProperties().Where(p => p.Name != primaryKey);
//		//		var setClause = string.Join(",", properties.Select(p => $"{p.Name} = @{p.Name}"));

//		//		string query = $"update {tableName} set {setClause} where {primaryKey} = @{primaryKey}";

//		//		using(var  cmd = new SqlCommand(query, con))
//		//		{
//		//			foreach(var property in properties)
//		//			{
//		//				cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(entity));
//		//			}
//		//			cmd.Parameters.AddWithValue("@" + primaryKey, typeof(T).GetProperty(primaryKey).GetValue(entity));

//		//			cmd.ExecuteNonQuery();
//		//		}
//		//	}
//		//}

//		//private T MapReaderToObj(SqlDataReader reader)
//		//{
//		//	var entity = Activator.CreateInstance<T>();
//		//	foreach(var property in typeof(T).GetProperties())
//		//	{
//		//		if(property.Name!="id")
//		//		{
//		//			property.SetValue(entity, reader[property.Name]);
//		//		}
//		//	}
//		//	return entity;	
//		//}
//	}
//}
