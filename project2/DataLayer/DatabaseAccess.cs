using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public static class DatabaseAccess 
    {
        //Vlozi do databaze novy zaznam s hodnotami parametru
        //Pri neuspechu vraci false.
        public static bool Insert(string type, DateTime date, double originalValue, string brand, int seatsNumber, double usage, SqlConnection conn)
        {
            try
            {
                conn.Open(); //otevreni spojeni

                //parametrizovany dotaz
                SqlCommand cmd = new SqlCommand(
                        "insert into Vehicles (Type, Date, OriginalValue, Brand, SeatsNumber, Usage) values (@Type, @Date, @OriginalValue, @Brand, @SeatsNumber, @Usage)", conn);

                //nastaveni parametru
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Type";
                param.Value = type;
                cmd.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Date";
                param2.Value = date;
                cmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@OriginalValue";
                param3.Value = originalValue;
                cmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@Brand";
                param4.Value = brand;
                cmd.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@SeatsNumber";
                param5.Value = seatsNumber;
                cmd.Parameters.Add(param5);
                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@Usage";
                param6.Value = usage;
                cmd.Parameters.Add(param6);

                //provedeni dotazu
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //uzavreni spojeni
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }

        //Vymaze zaznam s danym ID z databaze
        //Pri neuspechu vraci false.
        public static bool Remove(int ID, SqlConnection conn)
        {
            //parametrizovany dotaz
            SqlCommand cmd = new SqlCommand(
                        "delete from Vehicles where (ID = @ID)", conn);

            try
            {
                conn.Open(); //otevreni spojeni

                //nastaveni parametru
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                cmd.Parameters.Add(param);

                //provedeni dotazu
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                //uzavreni spojeni
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return true;
        }

        //Vraci ArrayList hodnot na radku z databaze daneho jeho poradim
        //Pri neuspechu vrati prazdny ArrayList
        public static ArrayList LoadRow(int rowNumber, SqlConnection conn)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand(
                    "select * from Vehicles", conn);
            ArrayList row = new ArrayList();

            try
            {
                conn.Open(); //otevreni spojeni
                reader = cmd.ExecuteReader();

                //posuneme se na pozadovany radek
                while (rowNumber > 0)
                {
                    if (reader.Read() == false) return row; //predcasny konec
                    rowNumber--;
                }

                //naplnime ArrayList pozadovanymi daty
                row.Add(reader.GetInt32(0)); //ID
                row.Add(reader.GetString(1)); //type
                row.Add(reader.GetDateTime(2)); //date
                row.Add(reader.GetInt32(3)); //origvalue
                row.Add(reader.GetString(4)); //brand
                row.Add(reader.GetInt32(5)); //seats
                row.Add(reader.GetDouble(6)); //usage
            }
            catch (Exception e)
            {
                row = new ArrayList(); //prazdny ArrayList
                return row;
            }
            finally
            {
                //uzavreni spojeni
                if (conn != null)
                {
                    conn.Close();
                }  
            }
            return row;  
        }
    }    
}
