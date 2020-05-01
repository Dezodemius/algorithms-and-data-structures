from Sort import sorts
from utils import tools, benchmarks


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
    a = tools.generate_array(n)
    decorated_func = benchmarks.stopwatch_recursion(func)
    decorated_func(a)
    return is_sorted(a)


def test_bubble_sort():
    n = 1000
    assert sort_checker(sorts.bubble, n) is True


def test_insertion_sort():
    n = 1000
    assert sort_checker(sorts.insertion, n) is True


def test_binary_insertion_sort():
    n = 1000
    assert sort_checker(sorts.binary_insertion, n) is True
