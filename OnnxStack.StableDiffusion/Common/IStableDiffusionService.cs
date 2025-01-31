﻿using Microsoft.ML.OnnxRuntime.Tensors;
using OnnxStack.StableDiffusion.Config;
using OnnxStack.StableDiffusion.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OnnxStack.StableDiffusion.Common
{
    public interface IStableDiffusionService
    {
        /// <summary>
        /// Loads the model.
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <returns></returns>
        Task<bool> LoadModelAsync(StableDiffusionModelSet model);


        /// <summary>
        /// Unloads the model.
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <returns></returns>
        Task<bool> UnloadModelAsync(StableDiffusionModelSet model);

        /// <summary>
        /// Determines whether the specified model is loaded
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <returns>
        ///   <c>true</c> if the specified model is loaded; otherwise, <c>false</c>.
        /// </returns>
        bool IsModelLoaded(StableDiffusionModelSet model);

        /// <summary>
        /// Generates the StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="options">The Scheduler options.</param>
        /// <param name="progressCallback">The callback used to provide progess of the current InferenceSteps.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The diffusion result as <see cref="DenseTensor<float>"/></returns>
        Task<DenseTensor<float>> GenerateAsync(StableDiffusionModelSet model, PromptOptions prompt, SchedulerOptions options, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates the StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="options">The Scheduler options.</param>
        /// <param name="progressCallback">The callback used to provide progess of the current InferenceSteps.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The diffusion result as <see cref="SixLabors.ImageSharp.Image<Rgba32>"/></returns>
        Task<Image<Rgba32>> GenerateAsImageAsync(StableDiffusionModelSet model, PromptOptions prompt, SchedulerOptions options, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates the StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="options">The Scheduler options.</param>
        /// <param name="progressCallback">The callback used to provide progess of the current InferenceSteps.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The diffusion result as <see cref="byte[]"/></returns>
        Task<byte[]> GenerateAsBytesAsync(StableDiffusionModelSet model, PromptOptions prompt, SchedulerOptions options, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates the StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="options">The Scheduler options.</param>
        /// <param name="progressCallback">The callback used to provide progess of the current InferenceSteps.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The diffusion result as <see cref="System.IO.Stream"/></returns>
        Task<Stream> GenerateAsStreamAsync(StableDiffusionModelSet model, PromptOptions prompt, SchedulerOptions options, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates a batch of StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <param name="promptOptions">The prompt options.</param>
        /// <param name="schedulerOptions">The scheduler options.</param>
        /// <param name="batchOptions">The batch options.</param>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<BatchResult> GenerateBatchAsync(StableDiffusionModelSet model, PromptOptions promptOptions, SchedulerOptions schedulerOptions, BatchOptions batchOptions, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates a batch of StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <param name="promptOptions">The prompt options.</param>
        /// <param name="schedulerOptions">The scheduler options.</param>
        /// <param name="batchOptions">The batch options.</param>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<Image<Rgba32>> GenerateBatchAsImageAsync(StableDiffusionModelSet model, PromptOptions promptOptions, SchedulerOptions schedulerOptions, BatchOptions batchOptions, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates a batch of StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <param name="promptOptions">The prompt options.</param>
        /// <param name="schedulerOptions">The scheduler options.</param>
        /// <param name="batchOptions">The batch options.</param>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<byte[]> GenerateBatchAsBytesAsync(StableDiffusionModelSet model, PromptOptions promptOptions, SchedulerOptions schedulerOptions, BatchOptions batchOptions, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates a batch of StableDiffusion image using the prompt and options provided.
        /// </summary>
        /// <param name="modelOptions">The model options.</param>
        /// <param name="promptOptions">The prompt options.</param>
        /// <param name="schedulerOptions">The scheduler options.</param>
        /// <param name="batchOptions">The batch options.</param>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<Stream> GenerateBatchAsStreamAsync(StableDiffusionModelSet model, PromptOptions promptOptions, SchedulerOptions schedulerOptions, BatchOptions batchOptions, Action<DiffusionProgress> progressCallback = null, CancellationToken cancellationToken = default);
    }
}