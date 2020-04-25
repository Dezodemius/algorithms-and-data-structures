from Sort.benchmarks import stopwatch
from Algorithm.Search import Search


def bubble(a, in_reverse=False):
    """ Bubble sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    if in_reverse:
        for i in range(1, len(a), 1):
            is_sorted = False
            for j in range(0, len(a) - i, 1):
                if a[j] < a[j + 1]:
                    a[j], a[j + 1] = a[j + 1], a[j]
                    is_sorted = False
            if is_sorted:
                return
    else:
        for i in range(1, len(a), 1):
            is_sorted = False
            for j in range(0, len(a) - i, 1):
                if a[j] > a[j + 1]:
                    a[j], a[j + 1] = a[j + 1], a[j]
                    is_sorted = False
            if is_sorted:
                return


def insertion(a, in_reverse=False):
    """Insertion sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    if in_reverse:
        return "Not supported now."
    else:
        for i in range(len(a)):
            j = 0
            while j < i and a[i] >= a[j]:
                j += 1
            while j < i:
                a[i], a[j] = a[j], a[i]
                j += 1


def binary_insertion(a, in_reverse=False):
    """Insertion sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    if in_reverse:
        return "Not supported now."
    else:
        n = len(a)
        for i in range(n):
            left = 0
            mid = n // 2
            right = i + 1

            key = a[i]

            while a[mid] != key and left <= right and:
                if key > a[mid]:
                    left = mid + 1
                else:
                    right = mid - 1
                mid = (left + right) // 2

            if left > right:
                return -1
            else:
                return mid
            while j < i:
                a[i], a[j] = a[j], a[i]
                j += 1


if __name__ == "__main__":
    print("Not for execution.")
