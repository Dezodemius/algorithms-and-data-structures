from Sort import sorts
from Algorithm.Search import Search
import random


from Sort.benchmarks import stopwatch_recursion


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
    decorated_func = stopwatch_recursion(func)
    decorated_func(a)
    return is_sorted(a)


def search_checker(func, n, *args):
    """Checks searches on generated array.

        :param func: Action.
        :param n: Number of elements.
        :param args: Arguments.
    """
    a = sorted(generate_array(n))
    key = random.choice(a)

    decorated_func = stopwatch_recursion(func)

    if len(args) != 0:
        founded_position = decorated_func(a, key, *args)
    else:
        founded_position = decorated_func(a, key)

    return key == a[founded_position]


def test_bubble_sort():
    n = 1000
    assert sort_checker(sorts.bubble, n) is True


def test_insertion_sort():
    n = 1000
    assert sort_checker(sorts.insertion, n) is True


def test_binary_insertion_sort():
    n = 1000
    assert sort_checker(sorts.binary_insertion, n) is True


def test_binary_search():
    n = 1000
    assert search_checker(Search.binary, n) is True, "he"


def test_binary_recursion_search():
    n = 1000
    assert search_checker(Search.binary_recursion, n, 0, n) is True


def test_exponential_search():
    n = 1000
    assert search_checker(Search.exponential, n) is True

