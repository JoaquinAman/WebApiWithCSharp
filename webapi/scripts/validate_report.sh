#!/bin/sh

echo "Check Report status"

REPORT_PATH="reports/report"

FILTER="Logic.cs:"

OBS=$(cat $REPORT_PATH | grep $FILTER)

echo $OBS

if [ -z "$OBS" ]
then
    echo "All OK!"
    exit 0
fi

cat $REPORT_PATH

exit 1
