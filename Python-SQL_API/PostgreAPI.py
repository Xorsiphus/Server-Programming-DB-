from datetime import datetime
import psycopg2
import random
import string


class PostgreSQL:

    def __init__(self, dbname_t, user_t, password_t, localhost_t):
        self.conn = psycopg2.connect(dbname=dbname_t, user=user_t,
                                     password=password_t, host=localhost_t)

    def show_table(self, table_name):
        cur = self.conn.cursor()
        cur.execute('SELECT * FROM {0}'.format(table_name))
        records = cur.fetchall()
        print(records)

    def gen_insert_str(self, count, table_name, column_names, *args):
        args_list = list(args)
        temp = 0
        request = 'INSERT INTO {0} ({1}) VALUES '.format(table_name, column_names)
        for _ in range(0, count):
            request += '('
            for i in args_list:
                if type(i) == int:
                    temp = self.gen_rand_int(i)
                    request += temp
                elif i[:5] == 'str[]':
                    request += '\'{'
                    for _ in range(0, random.randint(2, 4)):
                        request += self.gen_rand_str().replace('\'', '\"') + ', '
                    request += self.gen_rand_str().replace('\'', '\"')
                    request += '}\''
                elif i[:3] == 'str':
                    request += self.gen_rand_str()
                elif i[:3] == 'int':
                    request += str(self.gen_rand_int(9999))
                elif i[:6] == 'date_m':
                    request += self.gen_spec_movie_date(self.conn.cursor(), temp)
                elif i[:4] == 'date':
                    request += self.gen_rand_date()
                if i != args_list[-1]:
                    request += ', '
            request += '), '
        request = request[:-2] + ';'
        return request

    def execute_request(self, request):
        cur = self.conn.cursor()
        cur.execute(request)
        self.conn.commit()
        cur.close()

    def fill_companies_table(self, range_val):
        if range_val < 1:
            return
        request = self.gen_insert_str(range_val, 'companies', 'name, date', 'str', 'date_last')
        self.execute_request(request)

    def fill_personal_table(self, range_val):
        if range_val < 1:
            return
        max_val = self.get_max_val('companies', 'id')
        request = self.gen_insert_str(range_val, 'personal', 'company_id, name, b_date, position',
                                      max_val, 'str', 'date', 'str_last')
        self.execute_request(request)

    def fill_movies_table(self, range_val):
        if range_val < 1:
            return
        max_val = self.get_max_val('companies', 'id')
        request = self.gen_insert_str(range_val, 'movies', 'company_id, name, date, genre',
                                      max_val, 'str', 'date_m', 'str[]_last')
        self.execute_request(request)

    def fill_cinemas_table(self, range_val):
        if range_val < 1:
            return
        max_val = self.get_max_val('movies', 'id')
        request = self.gen_insert_str(range_val, 'cinemas', 'name, country, city, shared_film',
                                      'str', 'str', 'str', max_val)
        self.execute_request(request)

    def fill_tickets_table(self, range_val):
        if range_val < 1:
            return
        max_val_1 = self.get_max_val('cinemas', 'id')
        max_val_2 = self.get_max_val('movies', 'id')
        request = self.gen_insert_str(range_val, 'tickets', 'cinema_id, film_id',
                                      max_val_1, max_val_2)
        self.execute_request(request)

    def get_max_val(self, table_name, column_name):
        cur = self.conn.cursor()
        request = 'SELECT MAX({1}) FROM {0}'.format(table_name, column_name)
        cur.execute(request)
        res = cur.fetchall()
        cur.close()

        res = res[0]
        return res[0]

    @staticmethod
    def get_company_date(cur, comp_id):
        request = 'SELECT * FROM companies WHERE id = {0}'.format(comp_id)
        cur.execute(request)
        res = cur.fetchall()
        cur.close()

        res = res[0]
        return res[2]

    @staticmethod
    def gen_rand_str():
        return '\'' + random.choice(string.ascii_uppercase) + ''.\
            join(random.choice(string.ascii_lowercase) for _ in range(random.randint(5, 12))) + '\''

    @staticmethod
    def gen_rand_int(max_int):
        return '\'' + str(random.randint(1, max_int)) + '\''

    @staticmethod
    def gen_rand_date():
        timestamp = datetime.fromtimestamp(random.randint(0, 1600000000))
        return '\'' + str(timestamp.strftime('%m-%d-%Y')) + '\''

    @staticmethod
    def gen_spec_movie_date(cursor, comp_id):
        temp = PostgreSQL.get_company_date(cursor, comp_id)
        timestamp = datetime.fromtimestamp(random.randint((temp.year - 1970) * 31536000 + temp.month * 2678400 + temp.day * 86400, 1620000000))
        return '\'' + str(timestamp.strftime('%m-%d-%Y')) + '\''

    def close_conn(self):
        self.conn.close()
