const gulp = require('gulp');
const less = require('gulp-less');
const watch = require('gulp-watch');

gulp.task('compile-less', function(){
    gulp.src('./src/styles/index.less')
        .pipe(less())
        .pipe(gulp.dest('./'))
});

gulp.task('watch-less', function(){
    gulp.watch('./src/**/*.less', ['compile-less'])
});

gulp.task('default', ['compile-less', 'watch-less']);