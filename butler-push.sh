#!/bin/bash

butler push --if-changed Builds/mac dill0wn/no-brakes-taxi:mac
butler push --if-changed Builds/win dill0wn/no-brakes-taxi:win