#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Decorators for scripts tests."""
import collections
from datetime import datetime
import functools


def stopwatch(function):
    # TODO: Works not correctly for recursive calls.
    @functools.wraps(function)
    def wrapper_stopwatch(*args, **kwargs):
        start = datetime.now()
        res = function(*args, **kwargs)
        print("-->Finished '{0}' in {1:.8f} secs".format(function.__name__, datetime.now().timestamp() - start.timestamp()))
        return res
    wrapper_stopwatch._original = function
    return wrapper_stopwatch


def stopwatch_recursion(function):
    @functools.wraps(function)
    def wrapper_stopwatch(*args, **kwargs):
        @functools.wraps(function)
        def wrapper_under_recursion(*args, **kwargs):
            return function(*args, **kwargs)

        start = datetime.now()
        res = wrapper_under_recursion(*args, **kwargs)
        print("-->Finished '{0}' in {1:.8f} secs".format(function.__name__,
                                                         datetime.now().timestamp() - start.timestamp()))
        return res
    wrapper_stopwatch._original = function
    return wrapper_stopwatch


def average_runtime(repeat: int):
    def decorator_average_runtime(function):
        @functools.wraps(function)
        def wrapper_average_runtime(*args, **kwargs):
            all_time = 0.0
            for i in range(repeat):
                start = datetime.now()
                function(*args, **kwargs)
                all_time += (datetime.now() - start).total_seconds()
            else:
                print("-->Average runtime '{0}' is {1} secs".format(function.__name__, all_time / float(repeat)))

        return wrapper_average_runtime

    return decorator_average_runtime
