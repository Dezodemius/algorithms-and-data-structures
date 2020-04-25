from datetime import datetime
from Sort import sorts
from Algorithm.Search import Search
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


def is_sorted(a, in_reverse=False) -> bool:
    """ Check is a sorted.

        :param a: Input a.
        :param in_reverse: If sorted for descending. False by default.
        :return True if is sorted.
    """
    n = len(a)
    if in_reverse:
        for i in range(n - 1):
            if a[i] < a[i + 1]:
                return False
    else:
        for i in range(n - 1):
            if a[i] > a[i + 1]:
                return False
    return True


def sort_checker(func, n):
    """Checks sorts on generated array.

        :param func: Action.
        :param n: Number of elements.
    """
    a = generate_array(n)
    start = datetime.now().timestamp()
    func(a)
    finish = datetime.now().timestamp()

    print("-->Finished '{0}' in {1:.8f} secs".format(func.__name__, finish - start))
    print(f"{func.__name__}: {is_sorted(a)}")


def search_checker(func, n, *args):
    """Checks searches on generated array.

        :param func: Action.
        :param n: Number of elements.
        :param args: Arguments.
    """
    a = sorted(generate_array(n))
    key = random.choice(a)
    if len(args) != 0:
        start = datetime.now().timestamp()
        position = func(a, key, *args)
        finish = datetime.now().timestamp()
    else:
        start = datetime.now().timestamp()
        position = func(a, key)
        finish = datetime.now().timestamp()

    print("-->Finished '{0}' in {1:.8f} secs".format(func.__name__, finish - start))
    if position is not None:
        print(f"{func.__name__}: {a[position] == key}")
    else:
        print("Not found")


def main():
    """ The entry point."""
    n = 10

    search_checker(Search.binary, n)
    search_checker(Search.binary_recursion, n, 0, n)
    search_checker(Search.exponential, n)

    sort_checker(sorts.bubble, n)
    sort_checker(sorts.insertion, n)
    sort_checker(sorts.binary_insertion, n)


main()
