﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.DotNet.Cli.Utils;

namespace Microsoft.DotNet.Tools.Test.Utilities
{
    public sealed class PackCommand : DotnetCommand
    {
        private string _projectPath;
        private string _outputDirectory;
        private string _buildBasePath;
        private string _tempOutputDirectory;
        private string _configuration;
        private string _versionSuffix;
        private bool _serviceable;

        private string OutputOption => _outputDirectory == string.Empty ?
                                           "" :
                                           $"-o \"{_outputDirectory}\"";
        private string BuildBasePathOption => _buildBasePath == string.Empty ?
                                           "" :
                                           $"-b \"{_buildBasePath}\"";

        private string TempOutputOption => _tempOutputDirectory == string.Empty ?
                                           "" :
                                           $"-t {_tempOutputDirectory}";

        private string ConfigurationOption => _configuration == string.Empty ?
                                           "" :
                                           $"-c {_configuration}";

        private string VersionSuffixOption => _versionSuffix == string.Empty ?
                                           "" :
                                           $"--version-suffix {_versionSuffix}";

        private string ServiceableOption => _serviceable ?
                                $"--serviceable" :
                                "";

        public PackCommand WithConfiguration(string configuration)
        {
            _configuration = configuration;

            return this;
        }

        public PackCommand(
            string projectPath = "",
            string output = "",
            string buildBasePath = "",
            string tempOutput="", 
            string configuration="", 
            string versionSuffix="",
            bool serviceable = false)
        {
            _projectPath = projectPath;
            _outputDirectory = output;
            _buildBasePath = buildBasePath;
            _tempOutputDirectory = tempOutput;
            _configuration = configuration;
            _versionSuffix = versionSuffix;
            _serviceable = serviceable;
        }

        public override CommandResult Execute(string args = "")
        {
            args = $"pack {BuildArgs()} {args}";
            return base.Execute(args);
        }

        public override CommandResult ExecuteWithCapturedOutput(string args = "")
        {
            args = $"pack {BuildArgs()} {args}";
            return base.ExecuteWithCapturedOutput(args);
        }

        private string BuildArgs() => $"{_projectPath} {OutputOption} {BuildBasePathOption} {TempOutputOption} {ConfigurationOption} {VersionSuffixOption} {ServiceableOption}";
    }
}
