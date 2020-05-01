import random
from Algorithm.Search import Search
from utils import tools, benchmarks


def search_checker(func, n, *args):
    """Checks searches on generated array.

        :param func: Action.
        :param n: Number of elements.
        :param args: Arguments.
    """
    a = sorted(tools.generate_array(n))
    key = random.choice(a)

    decorated_func = benchmarks.stopwatch_recursion(func)

    if len(args) != 0:
        founded_position = decorated_func(a, key, *args)
    else:
        founded_position = decorated_func(a, key)

    return key == a[founded_position]


def test_binary_search():
    n = 1000
    assert search_checker(Search.binary, n) is True, "he"


def test_binary_recursion_search():
    n = 1000
    assert search_checker(Search.binary_recursion, n, 0, n) is True


def test_exponential_search():
    n = 1000
    assert search_checker(Search.exponential, n) is True
