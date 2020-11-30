import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

public class JDBC_test {

    public static void main(String[] args){
        String url = "jdbc:postgresql://1.1.1.11:5432/Test_DB";
        String user = "postgres";
        String pass = "super";
        Connection connection = null;

        try {
            Class.forName("org.postgresql.Driver");
            connection = DriverManager.getConnection(url, user, pass);

            Statement statement = connection.createStatement();

            ResultSet result = statement.executeQuery("SELECT * FROM companies");

            while(result.next()){
                System.out.println(result.getInt("id") + ") " + result.getString("name")
                        + "; " + result.getDate("date"));
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (connection != null)
            {
                try
                {
                    connection.close();
                } catch (Exception e)
                {
                    e.printStackTrace();
                }
            }
        }

    }

}
