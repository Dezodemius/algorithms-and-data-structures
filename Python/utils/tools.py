import random


def generate_array(n):
    """ Генератор случайного массива.

        :param n: Array size.
        :return Generated array.
    """
    array = []
    for i in range(n):
        array.append(random.randint(-n, n))
    return array
