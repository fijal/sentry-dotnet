#!/bin/sh
set -e errexit

framework=net462
dotnet build -c Release -f $framework
dotnet bin/Release/$framework/Sentry.Benchmarks.dll
