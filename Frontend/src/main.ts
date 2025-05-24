import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http';

// Merge your custom config with HTTP provider
const mergedConfig = {
  ...appConfig,
  providers: [
    ...(appConfig.providers || []),
    provideHttpClient(), // Add HttpClient provider
    // Add other providers here if needed
  ]
};

// Single bootstrap call with merged configuration
bootstrapApplication(AppComponent, mergedConfig)
  .catch((err) => console.error(err));