from PostgreAPI import PostgreSQL

if __name__ == '__main__':
    bd = PostgreSQL('Test_DB_2', 'postgres', 'super', 'localhost')

    companies_t_records_count = 100
    personal_t_records_count = 50000
    movies_t_records_count = 20000
    cinemas_t_records_count = 100000
    tickets_t_records_count = 1000000

    bd.fill_companies_table(companies_t_records_count)
    bd.fill_personal_table(personal_t_records_count)
    bd.fill_movies_table(movies_t_records_count)
    bd.fill_cinemas_table(cinemas_t_records_count)
    bd.fill_tickets_table(tickets_t_records_count)

    bd.close_conn()
