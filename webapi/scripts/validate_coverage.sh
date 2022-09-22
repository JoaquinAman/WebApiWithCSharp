#!/bin/bash

echo "Check Coverage"

COVERAGE_REPORT_PATH="./reports/coverage.cobertura.xml"

RATE_REGEX='[0-1]\d*(\.\d+)?'

RATE=$( awk 'NR==2' $COVERAGE_REPORT_PATH | grep -Pio $RATE_REGEX | sed -n '1p')

# Represents 100% of coverage
MAX_COVERAGE="1"

if [ "$RATE" = "$MAX_COVERAGE" ];
then
    echo "Pass Successful"
    exit 0
fi

# Represents 50% of coverage
MIN_COVERAGE="5"

COVERAGE_VALUE=$( echo $RATE | tr "." "\n" | sed -n '2p' | cut -c1-1 )

if [ "$COVERAGE_VALUE" -ge "$MIN_COVERAGE" ];
then
    echo "Pass Successful"
    exit 0
fi

echo "Fail Coverage Check!"

exit 1
