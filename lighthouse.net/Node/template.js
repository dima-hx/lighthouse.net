const lighthouse = require('C:\\Users\\dimah\\AppData\\Roaming\\npm\\node_modules\\lighthouse');
const chromeLauncher = require('C:\\Users\\dimah\\AppData\\Roaming\\npm\\node_modules\\lighthouse\\node_modules\\chrome-launcher');


function launchChromeAndRunLighthouse(url, opts, config = null) {
    return chromeLauncher.launch({ chromeFlags: opts.chromeFlags }).then(chrome => {
        opts.port = chrome.port;
        return lighthouse(url, opts, config).then(results => {
            // use results.lhr for the JS-consumeable output
            // https://github.com/GoogleChrome/lighthouse/blob/master/types/lhr.d.ts
            // use results.report for the HTML/JSON/CSV output as a string
            // use results.artifacts for the trace/screenshots/other specific case you need (rarer)
            return chrome.kill().then(() => results.lhr)
        });
    });
}

const opts = {
    chromeFlags: ['--show-paint-rects']
};

// Usage:
launchChromeAndRunLighthouse('https://example.com', opts).then(results => {
    // Use results!
    console.log(JSON.stringify(results));
});