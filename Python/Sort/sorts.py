from Algorithm.Search import Search
import random


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
    """ Insertion sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    n = len(a)
    if in_reverse:
        for i in range(n - 2, -1, -1):
            j = n - 1
            while j > i and a[i] >= a[j]:
                j -= 1
            while j > i:
                a[i], a[j] = a[j], a[i]
                j -= 1
    else:
        for i in range(1, n):
            j = 0
            while j < i and a[i] >= a[j]:
                j += 1
            while j < i:
                a[i], a[j] = a[j], a[i]
                j += 1


def binary_insertion(a):
    """ Insertion sort.

        :param a: Input array.
    """
    n = len(a)
    for i in range(1, n):
        key = a[i]
        key_position = Search.binary_recursion(a, key, 0, i) + 1
        for k in range(i, key_position, -1):
            a[k] = a[k - 1]
        a[key_position] = key


def shell(a):
    """ Shell's sort.

        :param a: Input array.
    """
    n = len(a)
    step = n // 2

    while step > 0:
        for i in range(step, n):
            tmp = a[i]
            j = i
            while j >= step and a[j - step] > tmp:
                a[j] = a[j - step]
                j -= step
            a[j] = tmp
        step //= 2


def selection(a):
    """ Selection sort.

        :param a: Input array.
    """
    n = len(a)
    for i in range(n):
        min_index, min_value = i, a[i]
        for j in range(i + 1, n):
            if a[j] < min_value:
                min_index = j
                min_value = a[j]
        a[i], a[min_index] = min_value, a[i]


def quick(a):
    """ Quick sort.

        :param a: Input array.
    """
    if len(a) <= 1:
        return a
    mid = a[len(a) // 2]

    return quick([n for n in a if n < mid]) + [mid] * a.count(mid) + quick([n for n in a if n > mid])


def heap(a):
    """ Heap sort.

        :param a: Input array.
    """
    def heapify(array, heap_size, current_index):
        """ Heapify array.

        :param array: Input array.
        :param heap_size: Size of heap.
        :param current_index: Root index.
        """
        root = current_index
        left_child = 2 * current_index + 1
        right_child = 2 * current_index + 2

        if left_child < heap_size and array[current_index] < array[left_child]:
            root = left_child

        if right_child < heap_size and array[root] < array[right_child]:
            root = right_child
        if root != current_index:
            array[current_index], array[root] = array[root], array[current_index]

            heapify(array, heap_size, root)

    n = len(a)

    for i in range(n // 2 - 1, -1, -1):
        heapify(a, n, i)

    for i in range(n - 1, 0, -1):
        a[i], a[0] = a[0], a[i]
        heapify(a, i, 0)


if __name__ == "__main__":
    print("Not for execution.")
